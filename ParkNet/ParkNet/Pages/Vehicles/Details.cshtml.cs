namespace ParkNet.Pages.Vehicles;

[Authorize]
public class DetailsModel : PageModel
{
    private readonly ParkNet.Data.ApplicationDbContext _context;

    public DetailsModel(ParkNet.Data.ApplicationDbContext context)
    {
        _context = context;
    }

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
}
