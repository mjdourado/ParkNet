namespace ParkNet.Pages.Parks;

public class IndexModel : PageModel
{
    private readonly ParkNet.Data.ApplicationDbContext _context;

    public IndexModel(ParkNet.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Park> Park { get;set; } = default!;

    public async Task OnGetAsync()
    {
        Park = await _context.Parks.ToListAsync();
    }
}
