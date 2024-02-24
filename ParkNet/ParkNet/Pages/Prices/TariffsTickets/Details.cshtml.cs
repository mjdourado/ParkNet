namespace ParkNet.Pages.Prices.TariffsTickets;

public class DetailsModel : PageModel
{
    private readonly ParkNet.Data.ApplicationDbContext _context;

    public DetailsModel(ParkNet.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public TariffTicket TariffTicket { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var tariffticket = await _context.TariffTickets.FirstOrDefaultAsync(m => m.Id == id);
        if (tariffticket == null)
        {
            return NotFound();
        }
        else
        {
            TariffTicket = tariffticket;
        }
        return Page();
    }
}
