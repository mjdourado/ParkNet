namespace ParkNet.Data.Repositories;

public class TariffPermitReposiitory
{
    private readonly ParkNet.Data.ApplicationDbContext _context;

    public TariffPermitReposiitory(ParkNet.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<TariffPermit>> GetTariffPermitsAsync()
    {
        return await _context.TariffPermits.ToListAsync();
    }

    public async Task<TariffPermit> GetTariffPermitById(int id)
    {
        return await _context.TariffPermits.FindAsync(id);
    }

    public async Task<TariffPermit> AddTariffPermit(TariffPermit tariffPermit)
    {
        _context.TariffPermits.Add(tariffPermit);
        await _context.SaveChangesAsync();
        return tariffPermit;
    }

    public async Task<TariffPermit> UpdateTariffPermit(TariffPermit tariffPermit)
    {
        _context.Attach(tariffPermit).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return tariffPermit;
    }

    public async Task DeleteTariffPermit(int id)
    {
        var tariffPermit = await _context.TariffPermits.FirstOrDefaultAsync(t => t.Id == id);
        _context.TariffPermits.Remove(tariffPermit);
        await _context.SaveChangesAsync();
    }
}
