namespace ParkNet.Pages.Prices.TariffsPermits;

[Authorize]
public class CreateModel : PageModel
{
    private readonly ParkNet.Data.ApplicationDbContext _context;

    public CreateModel(ParkNet.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        var permitTypes = Enum.GetValues(typeof(PermitType)).Cast<PermitType>().ToList();
        ViewData["PermitType"] = new SelectList(permitTypes);
        return Page();
    }

    [BindProperty]
    public TariffPermit TariffPermit { get; set; } = default!;
    [BindProperty]
    public Permit Permit { get; set; }

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.TariffPermits.Add(TariffPermit);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
