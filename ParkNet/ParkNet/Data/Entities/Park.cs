using System.ComponentModel.DataAnnotations;

namespace ParkNet.Data.Entities;

public class Park
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public string City { get; set; }
    [Required]
    public string Country { get; set; }
    [Required]
    public string CountryCode { get; set; }
    [Required]
    public int PhoneNumber { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string ImageData { get; set; }
    [Required]
    public string ParkLayout { get; set; }
}
