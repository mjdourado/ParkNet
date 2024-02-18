using System.ComponentModel.DataAnnotations;

namespace ParkNet.Data.Entities;

public class TariffTicket
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string VehicleType { get; set; }
    [Required]
    public TimeOnly Time { get; set; }
    [Required]
    public float Price { get; set; }
}
