namespace ParkNet.Data.Entities;

public class Ticket
{
    [Key]
    public int Id { get; set; }
    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; }
    public int TicketNumber { get; set; }
    [Required]
    public int ParkId { get; set; }
    public Park Park { get; set; }
}


