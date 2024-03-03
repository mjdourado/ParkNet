namespace ParkNet.Data.Repositories;

public class TariffTicketRepository
{
    private readonly ParkNet.Data.ApplicationDbContext _context;

    public TariffTicketRepository(ParkNet.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<TariffTicket>> GetAllAsync()
    {
        return await _context.TariffTickets.ToListAsync();
    }

    public async Task<TariffTicket> GetByIdAsync(int id)
    {
        return await _context.TariffTickets.FindAsync(id);
    }

    public async Task<TariffTicket> AddAsync(TariffTicket tariffTicket)
    {
        _context.TariffTickets.Add(tariffTicket);
        await _context.SaveChangesAsync();

        return tariffTicket;
    }

    public async Task<TariffTicket> UpdateAsync(TariffTicket tariffTicket)
    {
        _context.Attach(tariffTicket).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return tariffTicket;
    }
    
    public async Task DeleteAsync(int id)
    {
        var tariffTicket = await _context.TariffTickets.FirstOrDefaultAsync(t => t.Id == id);
        _context.TariffTickets.Remove(tariffTicket);
        await _context.SaveChangesAsync();
    }
}
