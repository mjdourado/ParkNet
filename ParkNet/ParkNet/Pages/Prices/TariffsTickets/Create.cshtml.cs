namespace ParkNet.Pages.Prices.TariffsTickets;

public class CreateModel : PageModel
{
    private readonly ParkNet.Data.ApplicationDbContext _context;

    public CreateModel(ParkNet.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public TariffTicket TariffTicket { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.TariffTickets.Add(TariffTicket);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
