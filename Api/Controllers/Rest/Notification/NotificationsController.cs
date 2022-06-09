﻿using Api.Controllers.Rest.Notification;
using Api.UserFeatures.Requests;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.IRepository;
using Application.Utilities;
using Domain.Constants;
using Domain.Entities;
using Domain.Entities.Notification;
using Domain.Entities.Room;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Rest;

public class NotificationsController : BaseRestController
{
    private readonly IGenericRepository<NotificationEntity> _notificationsRepository;
    private readonly IGenericRepository<NotificationTransaction> _transactionRepository;
    private readonly IGenericRepository<HostelEntity> _hostelRepository;
    private readonly IGenericRepository<RoomEntity> _roomRepository;
    private readonly IAuthorizationServices _authorServices;
    private readonly HandleNotificationRequest _reqHandler;

    public NotificationsController
        (IGenericRepository<NotificationEntity> notificationsRepository,
        IGenericRepository<NotificationTransaction> transactionRepository,
        IGenericRepository<HostelEntity> hostelRepository,
        IGenericRepository<RoomEntity> roomRepository,
        IAuthorizationServices authorServices,
        HandleNotificationRequest reqHandler)
    {
        _notificationsRepository = notificationsRepository;
        _authorServices = authorServices;
        _reqHandler = reqHandler;
        _transactionRepository = transactionRepository;
        _hostelRepository = hostelRepository;
        _roomRepository = roomRepository;
    }

    /// <summary>
    /// transaction create but cancel
    /// </summary>
    /// <param name="req"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="NotFoundException"></exception>
    [Authorize(Policy = PolicyName.ONWER_AND_MANAGER)]
    [HttpPost("create-but-cancel")]
    public async Task<IActionResult> CreateButCancelNotificationsAsync
        ([FromBody] CreateNotificationRequest req)
    {
        if (!req.RoomIds.Any())
        {
            throw new ArgumentException();
        }
        HostelEntity hostel = await _hostelRepository.FindByIdAsync(req.HostelId);
        if (hostel is null)
        {
            throw new NotFoundException("Hostel not found");
        }
        IList<NotificationEntity> notifications = new List<NotificationEntity>();
        bool isSent = false;

        if (req.TransactionId is null)
        {
            // create ==> issent false
            NotificationTransaction transaction = new()
            {
                Id = Guid.NewGuid(),
                ManagerId = CurrentUserID
            };

            req.TransactionId = transaction.Id;
            notifications = await _reqHandler.GetValidListFromRequest(req, CurrentUserID, isSent);
            transaction.HostelId = hostel.Id;
            await _transactionRepository.CreateAsync(transaction);
            await _notificationsRepository.CreateRangeAsync(notifications);
        }
        else
        {
            NotificationTransaction transaction = await _transactionRepository.FindByIdAsync((Guid)req.TransactionId);
            if (transaction is null)
            {
                throw new NotFoundException("Transcantion not found");
            }
            if (!transaction.HostelId.Equals(hostel.Id))
            {
                throw new BadRequestException("Cannot access");
            }
            // load db end update if any ==> issent still false
            notifications = await _reqHandler.GetValidListFromRepoAndUpdate(req, CurrentUserID, Mapper);
            foreach (NotificationEntity notification in notifications)
            {
                // noti has been sent
                if (notification.IsSent)
                {
                    throw new BadRequestException("Cannot access");
                }
            }
            await _notificationsRepository.UpdateRangeAsync(notifications);
        }
        return Ok(notifications);
    }


    /// <summary>
    /// send notis for chose room
    /// </summary>
    /// <param name="req"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="NotFoundException"></exception>
    [Authorize(Policy = PolicyName.ONWER_AND_MANAGER)]
    [HttpPost("send")]
    public async Task<IActionResult> SendNotificationsAsync
        ([FromBody] CreateNotificationRequest req)
    {
        if (!req.RoomIds.Any())
        {
            throw new ArgumentException();
        }
        HostelEntity hostel = await _hostelRepository.FindByIdAsync(req.HostelId);
        if (hostel is null)
        {
            throw new NotFoundException("Hostel not found");
        }
        IList<NotificationEntity> notifications = new List<NotificationEntity>();
        bool isSent = true;

        if (req.TransactionId is null)
        {
            NotificationTransaction transaction = new()
            {
                Id = Guid.NewGuid(),
                ManagerId = CurrentUserID
            };

            req.TransactionId = transaction.Id;
            notifications = await _reqHandler.GetValidListFromRequest(req, CurrentUserID, isSent);
            transaction.HostelId = hostel.Id;
            await _transactionRepository.CreateAsync(transaction);
            await _notificationsRepository.CreateRangeAsync(notifications);
        }
        else
        {
            // update issent true
            NotificationTransaction transaction = await _transactionRepository.FindByIdAsync((Guid)req.TransactionId);
            if (transaction is null)
            {
                throw new NotFoundException("Transcantion not found");
            }
            if (!transaction.HostelId.Equals(hostel.Id))
            {
                throw new BadRequestException("Cannot access");
            }
            notifications = await _reqHandler.GetValidListFromRepoAndUpdate(req, CurrentUserID, Mapper);
            foreach (NotificationEntity notification in notifications)
            {
                // noti has been sent
                if (notification.IsSent)
                {
                    throw new BadRequestException("Cannot access");
                }
                notification.IsSent = isSent;
            }
            await _notificationsRepository.UpdateRangeAsync(notifications);
        }
        return Ok(notifications);
    }

    /// <summary>
    /// get all notis of a transaction
    /// </summary>
    /// <param name="transactionId"></param>
    /// <returns></returns>
    /// <exception cref="NotFoundException"></exception>
    /// <exception cref="ForbiddenException"></exception>
    [Authorize(Policy = PolicyName.ONWER_AND_MANAGER)]
    [HttpGet("transaction/{transactionId}")]
    public async Task<IActionResult> GetNotiStransactionAsync
        ([FromRoute] Guid transactionId)
    {
        NotificationTransaction transaction = await _transactionRepository.FindByIdAsync(transactionId);
        if (transaction is null)
        {
            throw new NotFoundException("Transaction not found");
        }
        bool isManagedByCurrentUser = await _authorServices.IsHostelManagedByCurrentUser(transaction.HostelId, CurrentUserID);
        if (!isManagedByCurrentUser)
        {
            throw new ForbiddenException("Cannot access the request");
        }
        IList<NotificationEntity> notifications = await _notificationsRepository.WhereAsync(noti =>
        noti.TransactionId.Equals(transactionId));
        return Ok(notifications);
    }

    [Authorize(Policy = PolicyName.ONWER_AND_MANAGER)]
    [HttpDelete("transaction/{transactionId}")]
    public async Task<IActionResult> DeleteNotiStransactionAsync
        ([FromRoute] Guid transactionId)
    {
        NotificationTransaction transaction = await _transactionRepository.FindByIdAsync(transactionId);
        if (transaction is null)
        {
            throw new NotFoundException("Transaction not found");
        }
        bool isManagedByCurrentUser = await _authorServices.IsHostelManagedByCurrentUser(transaction.HostelId, CurrentUserID);
        if (!isManagedByCurrentUser)
        {
            throw new ForbiddenException("Cannot access the request");
        }
        transaction.IsDeleted = true;
        await _transactionRepository.UpdateAsync(transaction);
        return Ok();
    }

    [Authorize(Roles = nameof(Role.Tenant))]
    [HttpGet("{notiId}")]
    public async Task<IActionResult> ReadNotificationAsync([FromRoute] Guid notiId)
    {
        NotificationEntity noti = await _notificationsRepository.FindByIdAsync(notiId);
        if (noti == null)
        {
            throw new NotFoundException("Not found notification");
        }

        if (!noti.IsSent)
        {
            throw new BadRequestException("Cannot access");
        }

        bool isCurrentUserRentTheRoom = await _authorServices.IsCurrentUserRentTheRoom(noti.RoomId, CurrentUserID);
        if (!isCurrentUserRentTheRoom)
        {
            throw new ForbiddenException("Forbidden");
        }
        noti.IsUnread = false;
        await _notificationsRepository.UpdateAsync(noti);
        return Ok(noti);
    }

    [Authorize(Roles = nameof(Role.Tenant))]
    [HttpDelete("{notiId}")]
    public async Task<IActionResult> DeleteNotificationAsync([FromRoute] Guid notiId)
    {
        var noti = await _notificationsRepository.FindByIdAsync(notiId);
        if (noti == null)
        {
            throw new NotFoundException("Not found notification");
        }

        if (!noti.IsSent)
        {
            throw new BadRequestException("Cannot access");
        }

        bool isCurrentUserRentTheRoom = await _authorServices.IsCurrentUserRentTheRoom(noti.RoomId, CurrentUserID);
        if (!isCurrentUserRentTheRoom)
        {
            throw new ForbiddenException("Forbidden");
        }
        noti.IsDeleted = true;
        await _notificationsRepository.UpdateAsync(noti);
        return Ok();
    }
}