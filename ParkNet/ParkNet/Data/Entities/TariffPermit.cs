namespace ParkNet.Data.Entities;

public class TariffPermit
{
    [Key]
    public int Id { get; set; }
    [Required]
    public VehicleType VehicleType { get; set; }
    [Required]
    public PermitType PermitType { get; set; }
    public decimal Price { get; set; }
}

