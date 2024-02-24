namespace ParkNet.Pages.Prices.TariffsTickets;

public class IndexModel : PageModel
{
    private readonly ParkNet.Data.ApplicationDbContext _context;

    public IndexModel(ParkNet.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<TariffTicket> TariffTicket { get;set; } = default!;

    public async Task OnGetAsync()
    {
        TariffTicket = await _context.TariffTickets.ToListAsync();
    }
}
