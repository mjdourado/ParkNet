namespace ParkNet.Data.Entities;

public class TariffTicket
{
    [Key]
    public int Id { get; set; }
    [Required]
    public VehicleType Type { get; set; }
    [Required]
    public Period Time { get; set; }
    [Required]
    public decimal Price { get; set; }
}

public enum Period
{
    QuarterHourly = 15,
    HalfHourly = 30,
    Hourly = 60
}