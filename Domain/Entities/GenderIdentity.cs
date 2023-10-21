﻿using System.ComponentModel.DataAnnotations;

namespace PrototypeBackend.Entities;

public class GenderIdentity : BaseEntity
{
    [Key]
    public int GenderIdentityId { get; set; }
    
    [MaxLength(100)]
    public string Value { get; set; } = null!;
}