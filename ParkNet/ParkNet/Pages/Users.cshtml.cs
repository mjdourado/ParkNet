namespace ParkNet.Pages;

public class UsersModel : PageModel
{
    private readonly ParkNet.Data.ApplicationDbContext _context;

    public UsersModel(ParkNet.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Customer> Customer { get;set; }

    public async Task OnGetAsync()
    {
        Customer = await _context.Customers.ToListAsync();
    }
}
