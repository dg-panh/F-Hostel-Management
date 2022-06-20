﻿using Api.Filters;
using Api.UserFeatures.Requests;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.IRepository;
using Domain.Constants;
using Domain.Entities.Commitment;
using Domain.Entities.Facility;
using Domain.Entities.InvoiceSchedule;
using Domain.Entities.Room;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Rest;

public class RoomsController : BaseRestController
{
    private readonly IGenericRepository<RoomEntity> _roomsRepository;
    private readonly IGenericRepository<CommitmentEntity> _commitmentRepository;
    private readonly ICommitmentServices _commitmentServices;
    private readonly IAuthorizationServices _authorServices;
    private readonly IGenericRepository<FacilityEntity> _facilityRepo;
    private readonly IGenericRepository<FacilityManagement> _facilityManagementRepo;
    private readonly IGenericRepository<InvoiceScheduleEntity> _invoiceScheduleRepository;

    public RoomsController
        (IGenericRepository<RoomEntity> roomsRepository, 
        IGenericRepository<CommitmentEntity> commitmentRepository, 
        ICommitmentServices commitmentServices, 
        IAuthorizationServices authorServices, 
        IGenericRepository<FacilityEntity> facilityRepo, 
        IGenericRepository<FacilityManagement> facilityManagementRepo,
        IGenericRepository<InvoiceScheduleEntity> invoiceScheduleRepository)
    {
        _roomsRepository = roomsRepository;
        _commitmentRepository = commitmentRepository;
        _commitmentServices = commitmentServices;
        _authorServices = authorServices;
        _facilityRepo = facilityRepo;
        _facilityManagementRepo = facilityManagementRepo;
        _invoiceScheduleRepository = invoiceScheduleRepository;
    }


 
    /// <summary>
    /// owner || manager create room of their hostel
    /// </summary>
    /// <param name="req"></param>
    /// <returns></returns>
    [Authorize(Policy = PolicyName.ONWER_AND_MANAGER)]
    [HttpPost()]
    public async Task<IActionResult> CreateRoomsAsync(CreateRoomsRequest req)
    {
        bool isManagedByCurrentUser = await _authorServices.IsHostelManagedByCurrentUser(req.HostelId, CurrentUserID);
        if (!isManagedByCurrentUser)
        {
            return Forbid();
        }

        if (req.RoomName == null)
        {
            req.RoomName = "Unnamed";
        }

        List<RoomEntity> rooms = new();
        while (req.Quantity > 0)
        {
            var room = Mapper.Map<RoomEntity>(req);
            room.RoomStatus = RoomStatus.Available;
            rooms.Add(room);
            req.Quantity--;
        }

        await _roomsRepository.CreateRangeAsync(rooms);
        return Ok();
    }

    /// <summary>
    /// only tenant get their commitments of that room
    /// </summary>
    /// <param name="roomId"></param>
    /// <returns></returns>
    [Authorize(Roles = nameof(Role.Tenant))]
    [HttpGet("{roomId}/get-list-commitment-of-room-for-tenant")]
    public async Task<IActionResult> GetCommitmentsForTenant
    ([FromRoute] Guid roomId)
    {
        var coms = await _commitmentServices.GetCommitmentsForTenant(roomId, CurrentUserID);
        return Ok(coms);
    }

    [HttpPost("add-facility")]
    public async Task<IActionResult> AddFacilityToRoom(AddFacilityToRoomRequest request)
    {
        bool isManagedByCurrentUser = await _authorServices.IsRoomManageByCurrentUser(request.RoomId, CurrentUserID);
        if (!isManagedByCurrentUser)
            throw new ForbiddenException("");
        foreach (var facility in request.FacilityRooms)
        {
            // var test = await _facilityRepo.ListAsync();
            var facilityTarget = await _facilityRepo.FirstOrDefaultAsync(e => e.Id.Equals(facility.FacilityId));
            if (facilityTarget is null)
                throw new BadRequestException("Facility is not valid");
            var targetManagement = await _facilityManagementRepo.FirstOrDefaultAsync(e => e.FacilityId.Equals(facility.FacilityId) && e.RoomId.Equals(request.RoomId));
            if (targetManagement is not null)
                throw new BadRequestException("The facility has been existed in the room!");
            if (facilityTarget.Quantity < facility.Quantity)
                throw new BadRequestException("The hostel does not have enough quantity for this facility!");
            // if (facilityTarget.Quantity < facility.Quantity)
            //     throw new BadRequestException("The hostel does not have enough quantity for this facility!");
            var entity = new FacilityManagement();
            entity.FacilityId = facility.FacilityId;
            entity.Quantity = facility.Quantity;
            entity.Description = facility.Description;
            entity.RoomId = request.RoomId;
            
            // Mapper.Map(request, entity);
            await _facilityManagementRepo.CreateAsync(entity);
        }
        return Ok();
    }
    [HttpPatch("update-facility")]
    public async Task<IActionResult> UpdateFacilityFromRoom(UpdateFacilityToRoomRequest request)
    {
        var target = await _facilityManagementRepo.FirstOrDefaultAsync(e => e.Id.Equals(request.FacilityManagementId));
        if (target is null)
            throw new BadRequestException("Facility is not valid");
        bool isManagedByCurrentUser = await _authorServices.IsRoomManageByCurrentUser(target.RoomId, CurrentUserID);
        if (!isManagedByCurrentUser)
            throw new ForbiddenException("");
        var facilityTarget = await _facilityRepo.FirstOrDefaultAsync(e => e.Id.Equals(target.FacilityId));
        if (facilityTarget is null)
            throw new BadRequestException("Facility is not valid");
        int total = facilityTarget.Quantity + target.Quantity;
        if (total < request.Quantity)
            throw new BadRequestException("The hostel does not have enough quantity for this facility!");
        Mapper.Map(request, target);
        await _facilityManagementRepo.UpdateAsync(target);
        return Ok();
    }
    [HttpDelete("delete-facility/{id}")]
    public async Task<IActionResult> DeleteFacilityFromRoom([FromRoute] Guid id)
    {
        var target = await _facilityManagementRepo.FirstOrDefaultAsync(e => e.Id.Equals(id));
        if (target is null)
            throw new BadRequestException("Facility is not valid");
        bool isManagedByCurrentUser = await _authorServices.IsRoomManageByCurrentUser(target.RoomId, CurrentUserID);
        if (!isManagedByCurrentUser)
            throw new ForbiddenException("");
        target.IsDeleted = true;
        await _facilityManagementRepo.UpdateAsync(target);
        return Ok();
    }

    [HttpPost("{roomId}/checkout")]
    public async Task<IActionResult> CheckoutThisRoom([FromRoute] Guid roomId)
    {
        RoomEntity room = await _roomsRepository.FindByIdAsync(roomId);
        if (room is null)
        {
            throw new NotFoundException("Room not found");
        }

        // set commitment to expired (if any)
        CommitmentEntity latestCommitment = await _commitmentServices.GetLatestCommitmentByRoom(roomId);
        if (latestCommitment.CommitmentStatus != CommitmentStatus.Expired)
        {
            latestCommitment.CommitmentStatus = CommitmentStatus.Expired;
            await _commitmentRepository.UpdateAsync(latestCommitment);
        }

        // remove all invoice schedule
        var schedules = await _invoiceScheduleRepository.WhereAsync(entity => entity.RoomId.Equals(roomId));
        foreach (var schedule in schedules)
        {
            schedule.IsDeleted = true;
        }
        await _invoiceScheduleRepository.UpdateRangeAsync(schedules);
        room.RoomStatus = RoomStatus.Available;
        await _roomsRepository.UpdateAsync(room);
        return Ok();
    }
}
