using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ParkNet.Data.Entities;

public class Customer
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public DateOnly BirthDate { get; set; }
    [Required]
    public int VatNumber { get; set; }
    [Required]
    public string DriversLicenseNumber { get; set; }
    [Required]
    public DateOnly DriversLicenseExpDate { get; set; }
    [Required]
    public string City { get; set; }
    [Required]
    public string Country { get; set; }
    [Required]
    public string CountryCode { get; set; }
    [Required]
    public int PhoneNumber { get; set; }
    [Required]
    public string PaymentMethod { get; set; }
    public int Balance { get; set; }
    public string UserId { get; set; }
    public IdentityUser User { get; set; }
}
