﻿using Application.Interfaces;
using Application.Interfaces.IRepository;
using Domain.Entities.Commitment;
using Domain.Entities.Room;
using Domain.Enums;

namespace Application.Services.CommitmentServices;

public class CommitmentServices : ICommitmentServices
{
    public readonly IGenericRepository<CommitmentEntity> _commitmentRepository;

    public CommitmentServices(
        IGenericRepository<CommitmentEntity> commitmentRepository
        )
    {
        _commitmentRepository = commitmentRepository;
    }

    public async Task CreateCommitment(CommitmentEntity commitment, RoomEntity room)
    {
        commitment.RoomId = room.Id;
        commitment.CommitmentStatus = CommitmentStatus.Pending;
        // save commitment
        await _commitmentRepository.CreateAsync(commitment);
    }

    public async Task<CommitmentEntity> GetCurrentCommitmentByRoom(Guid roomId)
    {
        return await _commitmentRepository
            .FirstOrDefaultAsync(com => 
            com.RoomId.Equals(roomId)
            && !com.Status.Equals(CommitmentStatus.Expired.ToString())
            );
    }

    public async Task<bool> IsExist(string commitmentCode)
    {
        return await _commitmentRepository
            .FirstOrDefaultAsync(com => com.CommitmentCode.Equals(commitmentCode))
            != null;
    }
}