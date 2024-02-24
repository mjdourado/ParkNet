namespace ParkNet.Pages.Vehicles;

[Authorize]
public class IndexModel : PageModel
{
    private readonly ParkNet.Data.ApplicationDbContext _context;

    public IndexModel(ParkNet.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Vehicle> Vehicle { get;set; } = default!;

    public async Task OnGetAsync()
    {
        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var vehicles = _context.Vehicles.Where(v => v.UserId == currentUserId);

        Vehicle = await vehicles.ToListAsync();
    }
}
