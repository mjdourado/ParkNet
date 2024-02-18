﻿using System.ComponentModel.DataAnnotations;

namespace ParkNet.Data.Entities;

public class ParkingSpace
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int FloorId { get; set; }
    [Required]
    public Floor Floor { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Status { get; set; }
    [Required]
    public string Type { get; set; }
}
