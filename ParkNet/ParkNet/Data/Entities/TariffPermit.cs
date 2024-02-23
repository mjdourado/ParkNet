using System.ComponentModel.DataAnnotations;

namespace ParkNet.Data.Entities;

public class TariffPermit
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string VehicleType { get; set; }
    public float Yearly { get; set; }
    public float Biannualy { get; set; }
    public float Quarterly { get; set; }
    public float Monthly { get; set; }
}
