﻿using System.ComponentModel.DataAnnotations;

namespace PrototypeBackend.Entities;

public class Occupation: BaseEntity
{
    [Key]
    public int OccupationId { get; set; }
    
    [MaxLength(100)]
    public string Value { get; set; } = null!;
}