namespace ParkNet.Data.Repositories;

public class FloorRepository
{
    private readonly ParkNet.Data.ApplicationDbContext _context;

    public FloorRepository(ParkNet.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Floor>> GetAllFloorsAsync()
    {
        return await _context.Floors.ToListAsync();
    }

    public async Task<Floor> GetFloorByIdAsync(int id)
    {
        return await _context.Floors.FindAsync(id);
    }

    public async Task<Floor> AddFloorAsync(Floor floor)
    {
        _context.Floors.Add(floor);
        await _context.SaveChangesAsync();

        return floor;
    }

    public async Task<Floor> UpdateFloorAsync(Floor floor)
    {
        _context.Attach(floor).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return floor;
    }

    public async Task DeleteFloorAsync(int id)
    {
        var floor = await _context.Floors.FirstOrDefaultAsync(t => t.Id == id);
        _context.Floors.Remove(floor);
        await _context.SaveChangesAsync();
    }
}
