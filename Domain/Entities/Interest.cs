﻿using System.ComponentModel.DataAnnotations;

namespace PrototypeBackend.Entities;

public class Interest: BaseEntity
{
    [Key]
    public int InterestId { get; set; }
    
    [MaxLength(100)]
    public string Value { get; set; } = null!;
}