namespace ParkNet.Pages.Vehicles;

[Authorize]
public class DeleteModel : PageModel
{
    private readonly ParkNet.Data.ApplicationDbContext _context;

    public DeleteModel(ParkNet.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Vehicle Vehicle { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var vehicle = await _context.Vehicles.FirstOrDefaultAsync(m => m.Id == id);

        if (vehicle == null)
        {
            return NotFound();
        }
        else
        {
            Vehicle = vehicle;
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var vehicle = await _context.Vehicles.FindAsync(id);
        if (vehicle != null)
        {
            Vehicle = vehicle;
            _context.Vehicles.Remove(Vehicle);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
