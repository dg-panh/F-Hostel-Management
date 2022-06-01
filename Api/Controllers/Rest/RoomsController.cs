﻿using Application.Interfaces.IRepository;
using Domain.Entities.Room;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Rest;

[Route("api/rooms")]
public class RoomsController : BaseRestController
{
    private readonly IGenericRepository<RoomEntity> _roomsRepository;
    public RoomsController(IGenericRepository<RoomEntity> roomsRepository)
    {
        _roomsRepository = roomsRepository;
    }

    [HttpGet()]
    public async Task<IActionResult> GetRoomsAsync()
    {
        return Ok(await _roomsRepository.ListAsync());
    }
}