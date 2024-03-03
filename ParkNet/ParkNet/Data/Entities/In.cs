namespace ParkNet.Data.Entities;

public class In
{
    [Key]
    public int Id { get; set; }
    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; }
    public int TicketNumber { get; set; }
    public int ParkingSpaceId { get; set; }
    [Required]
    public DateTime Enter { get; set; } = DateTime.Now;
}
