﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ParkNet.Data.Entities;

public class Vehicle
{
    public int Id { get; set; }
    [Required]
    public string Type { get; set; }
    [Required]
    public string LicensePlate { get; set; }
    [Required]
    public string Brand { get; set; }
    [Required]
    public string Model { get; set; }
    [Required]
    public string Color { get; set; }
    [Required]
    public int Year { get; set; }
    public string UserId { get; set; }
    public IdentityUser User { get; set; }
}
