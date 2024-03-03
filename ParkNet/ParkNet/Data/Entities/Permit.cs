namespace ParkNet.Data.Entities;

public class Permit
{
    [Key]
    public int Id { get; set; }
    [Required]
    public PermitType Type { get; set; }
    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; }
    [Required]
    public DateTime StartDate { get; set; } = DateTime.Now;
    [Required]
    public DateTime EndDate { get; set; }
    public int ParkId { get; set; }
    public int FloorId { get; set; }
    public int ParkingSpaceId { get; set; }
    public ParkingSpace ParkingSpace { get; set; }
    public decimal Price { get; set; }
}

public enum PermitType
{
    Monthly,
    Quarterly,
    Biannualy,
    Yearly
}
