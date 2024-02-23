using System.ComponentModel.DataAnnotations;

namespace ParkNet.Data.Entities;

public class Permit
{
    [Key]
    public int Id { get; set; }
    [Required]
    public PermitType Type { get; set; }
    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; }
    public int ParkingSpaceId { get; set; }
    public ParkingSpace ParkingSpace { get; set; }
    [Required]
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public string Status { get; set; }
}

public enum PermitType
{
    Monthly,
    Trimestral,
    Semestral,
    Yearly
}
