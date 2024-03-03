namespace ParkNet.Data.Repositories;

public class ParkingSpaceRepository
{
    private readonly ParkNet.Data.ApplicationDbContext _context;

    public ParkingSpaceRepository(ParkNet.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ParkingSpace>> GetAllParkingSpacesAsync()
    {
        return await _context.ParkingSpaces.ToListAsync();
    }

    public async Task<ParkingSpace> GetParkingSpaceByIdAsync(int id)
    {
        return await _context.ParkingSpaces.FindAsync(id);
    }

    public async Task<ParkingSpace> AddParkingSpaceAsync(ParkingSpace parkingSpace)
    {
        _context.ParkingSpaces.Add(parkingSpace);
        await _context.SaveChangesAsync();

        return parkingSpace;
    }

    public async Task<ParkingSpace> UpdateParkingSpaceAsync(ParkingSpace parkingSpace)
    {
        _context.Attach(parkingSpace).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return parkingSpace;
    }

    public async Task DeleteParkingSpaceAsync(int id)
    {
        var parkingSpace = await _context.ParkingSpaces.FirstOrDefaultAsync(t => t.Id == id);
        _context.ParkingSpaces.Remove(parkingSpace);
        await _context.SaveChangesAsync();
    }
}
