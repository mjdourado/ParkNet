using System.ComponentModel.DataAnnotations;

namespace ParkNet.Data.Entities;

public class TariffPermit
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string VehicleType { get; set; }
    public float AnualPrice { get; set; }
    public float SemesterPrice { get; set; }
    public float TrimesterPrice { get; set; }
    public float MonthlyPrice { get; set; }
}
