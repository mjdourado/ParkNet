namespace ParkNet.Data.Entities;

public class ParkingSpace
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int FloorId { get; set; }
    [Required]
    public Floor Floor { get; set; }
    [Required]
    public string Name { get; set; }
    public bool IsFree { get; set; } = true;
    [Required]
    public VehicleType Type { get; set; }
}
