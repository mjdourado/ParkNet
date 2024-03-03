namespace ParkNet.Pages.Transactions;

[Authorize]
public class CreateModel : PageModel
{
    private readonly ParkNet.Data.ApplicationDbContext _context;
    private readonly TransactionRepository _transactionRepository;

    public CreateModel(ApplicationDbContext context, TransactionRepository transactionRepository)
    {
        _context = context;
        _transactionRepository = transactionRepository;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Transaction Transactions { get; set; } = default!;

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var lastTransaction = _context.Transactions
            .Where(t => t.UserId == currentUserId)
            .OrderByDescending(t => t.Date)
            .FirstOrDefault();

        _transactionRepository.UpdateBalance(lastTransaction, Transactions);
        Transactions.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        _context.Transactions.Add(Transactions);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
