namespace ParkNet.Data.Repositories;

public class PermitRepository
{
    private readonly ApplicationDbContext _context;

    public PermitRepository(ApplicationDbContext context)
    {
        _context = context;
    }

public float PermitPrice(PermitType permitType, int vehicleId)
    {
    var vehicle = _context.Vehicles.FirstOrDefault(v => v.Id == vehicleId);
    var vehicleType = vehicle.Type;
    var tariff = _context.TariffPermits.FirstOrDefault(t => t.PermitType == permitType && t.VehicleType == vehicleType);
    return (float)tariff.Price;
    }

    public DateTime GetEndDate(DateTime startdate, PermitType permitType)
    {
        if (permitType == PermitType.Monthly)
        {
            return startdate.AddMonths(1);
        }
        else if (permitType == PermitType.Quarterly)
        {
            return startdate.AddMonths(3);
        }
        else if (permitType == PermitType.Biannualy)
        {
            return startdate.AddMonths(6);
        }
        else
        {
            return startdate.AddYears(1);
        }
    }
}
