namespace ParkNet.Pages.Prices.TariffsTickets;

public class DeleteModel : PageModel
{
    private readonly ParkNet.Data.ApplicationDbContext _context;

    public DeleteModel(ParkNet.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
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

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var tariffticket = await _context.TariffTickets.FindAsync(id);
        if (tariffticket != null)
        {
            TariffTicket = tariffticket;
            _context.TariffTickets.Remove(TariffTicket);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
