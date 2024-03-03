namespace ParkNet.Data.Entities;

public class Out
{
    public int Id { get; set; }
    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; }
    public int TicketNumber { get; set; }
    [Required]
    public DateTime Left { get; set; } = DateTime.Now;
    public decimal TotalTime { get; set; }
    public decimal TotalPrice { get; set; }

}
