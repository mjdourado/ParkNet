using System.ComponentModel.DataAnnotations;

namespace ParkNet.Data.Entities;

public class Permit
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Type { get; set; }
    public int vehicleId { get; set; }
    public Vehicle Vehicle { get; set; }
    public int ParkingSpaceId { get; set; }
    public ParkingSpace ParkingSpace { get; set; }
    [Required]
    public DateOnly StartDate { get; set; }
    [Required]
    public DateOnly EndDate { get; set; }
    [Required]
    public string Status { get; set; }
}
