﻿using Domain.Common;
using Domain.Entities.Room;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Entities.Commitment;
[Table("Commitments")]
public class CommitmentEntity : BaseEntity
{
    [Required]
    public string CommitmentCode { get; set; }
    [Required]
    public DateTime CreatedDate { get; set; }
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public DateTime? EndDate { get; set; }
    public string? Content { get; set; }

    /*navigation props*/

    // 1 Commitment (belong to) M Managers
    public Guid? ManagerId { get; set; }
    public UserEntity Manager { get; set; }

    // 1 tenants M commitment
    [Required]
    public Guid TenantId { get; set; }
    public UserEntity Tenant { get; set; }

    // 1 Owner M commitment
    [Required]
    public Guid OwnerId { get; set; }
    public UserEntity Owner { get; set; }

    // 1 Commitment (belong to) 1 Rooms
    [Required]
    public Guid RoomId { get; set; }
    public RoomEntity Room { get; set; }
}
