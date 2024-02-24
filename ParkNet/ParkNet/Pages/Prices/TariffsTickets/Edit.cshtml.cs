namespace ParkNet.Pages.Prices.TariffsTickets;

public class EditModel : PageModel
{
    private readonly ParkNet.Data.ApplicationDbContext _context;

    public EditModel(ParkNet.Data.ApplicationDbContext context)
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

        var tariffticket =  await _context.TariffTickets.FirstOrDefaultAsync(m => m.Id == id);
        if (tariffticket == null)
        {
            return NotFound();
        }
        TariffTicket = tariffticket;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(TariffTicket).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TariffTicketExists(TariffTicket.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool TariffTicketExists(int id)
    {
        return _context.TariffTickets.Any(e => e.Id == id);
    }
}
