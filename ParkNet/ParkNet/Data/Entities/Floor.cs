using System.ComponentModel.DataAnnotations;

namespace ParkNet.Data.Entities;

public class Floor
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int ParkId { get; set; }
    [Required]
    public Park Park { get; set; }
}
