namespace ParkNet.Pages.Prices.TariffsPermits;

public class IndexModel : PageModel
{
    private readonly ParkNet.Data.ApplicationDbContext _context;

    public IndexModel(ParkNet.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<TariffPermit> TariffPermit { get;set; } = default!;

    public async Task OnGetAsync()
    {
        TariffPermit = await _context.TariffPermits.ToListAsync();
    }
}
