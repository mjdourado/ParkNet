using Humanizer;
using System.ComponentModel.DataAnnotations;

namespace ParkNet.Data.Entities;

public class Ticket
{
    [Key]
    public int Id { get; set; }
    public int vehicleId { get; set; }
    public Vehicle Vehicle { get; set; }
    public int ParkingSpaceId { get; set; }
    public ParkingSpace ParkingSpace { get; set; }
    [Required]
    public DateTime In { get; set; } = DateTime.Now;
    [Required]
    public DateTime Out { get; set; } = DateTime.Now;
    public float TotalTime { get; set; }
}
