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

public class Ins
{
    [Key]
    public int Id { get; set; }
    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; }
    public int TicketNumber { get; set; }
    public int ParkingSpaceId { get; set; }
    [Required]
    public DateTime In { get; set; } = DateTime.Now;
}

public class Outs
{
    public int Id { get; set; }
    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; }
    public int TicketNumber { get; set; }
    [Required]
    public DateTime Out { get; set; } = DateTime.Now;
    public decimal TotalTime { get; set; }
    public decimal TotalPrice { get; set; }

}


