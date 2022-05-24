﻿using Api.UserFeatures.Requests;
using Api.UserFeatures.Responses;
using Application.Interfaces.IRepository;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistence.Repositories;

namespace Api.Controllers;

[Authorize]
public class UsersController : BaseApiController
{
    private readonly IGenericRepository<UserEntity> _userRepository;
    public UsersController(
        IGenericRepository<UserEntity> userRepository)
    {
        _userRepository = userRepository;
    }
    
    [HttpGet("get-info")]
    public async Task<IActionResult> GetInfo()
    {
        var user = await _userRepository.FirstOrDefaultAsync(e => e.Id.Equals(GetUserID()));
        GetInfoResponse infoResponse = new GetInfoResponse();
        Mapper.Map(user, infoResponse);
        return Ok(infoResponse);
    }

    [HttpPatch("update-info")]
    public async Task<IActionResult> UpdateInfo(UpdateUserRequest updateUserRequest)
    {

        return Ok();
    }

}
