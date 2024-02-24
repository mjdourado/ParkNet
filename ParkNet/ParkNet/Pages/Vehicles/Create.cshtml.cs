namespace ParkNet.Pages.Vehicles;

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
        return Page();
    }

    [BindProperty]
    public Vehicle Vehicle { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        Vehicle.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        _context.Vehicles.Add(Vehicle);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
