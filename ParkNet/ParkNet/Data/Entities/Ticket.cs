using Humanizer;
using System.ComponentModel.DataAnnotations;

namespace ParkNet.Data.Entities;

public class Ticket
{
    [Key]
    public int Id { get; set; }
    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; }
    public int TicketNumber { get; set; }
    public TimeSpan TotalTime { get; set; }
    public decimal TotalPrice { get; set; }
}

public class Ins
{
    [Key]
    public int Id { get; set; }
    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; }
    public int TicketNumber { get; set; }
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
}


