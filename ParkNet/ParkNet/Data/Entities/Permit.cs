namespace ParkNet.Data.Entities;

public class Permit
{
    [Key]
    public int Id { get; set; }
    [Required]
    public PermitType Type { get; set; }
    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; }
    [Required]
    public DateTime StartDate { get; set; } = DateTime.Now;
    [Required]
    public DateTime EndDate { get; set; }
    public int ParkId { get; set; }
    public int FloorId { get; set; }
    public int ParkingSpaceId { get; set; }
    public ParkingSpace ParkingSpace { get; set; }
    public decimal Price { get; set; }


    public Permit()
    {
        EndDate = GetEndDate();
    }

    public DateTime GetEndDate()
    {
        if (Type == PermitType.Monthly)
        {
            return StartDate.AddMonths(1);
        }
        else if (Type == PermitType.Quarterly)
        {
            return StartDate.AddMonths(3);
        }
        else if (Type == PermitType.Biannualy)
        {
            return StartDate.AddMonths(6);
        }
        else
        {
            return StartDate.AddYears(1);
        }
    }
}

public enum PermitType
{
    Monthly,
    Quarterly,
    Biannualy,
    Yearly
}

public class PermitViewModel
{
    public int Id { get; set; }
    public PermitType Type { get; set; }
    public int VehicleId { get; set; }
    public string VehiclePlate { get; set; }
    public DateTime StartDate { get; set; }
    public int ParkId { get; set; }
    public int FloorId { get; set; }
    public int ParkingSpaceId { get; set; }
    public decimal Price { get; set; }
}
