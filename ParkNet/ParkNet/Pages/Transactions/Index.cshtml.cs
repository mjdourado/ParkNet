namespace ParkNet.Pages.Transactions;

public class IndexModel : PageModel
{
    private readonly ParkNet.Data.ApplicationDbContext _context;

    public IndexModel(ParkNet.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Transaction> Transaction { get;set; } = default!;

    public async Task OnGetAsync()
    {
        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var transactions = _context.Transactions
            .Where(t => t.UserId == currentUserId)
            .OrderByDescending(t => t.Date);

        Transaction = await transactions.ToListAsync();
    }
}
