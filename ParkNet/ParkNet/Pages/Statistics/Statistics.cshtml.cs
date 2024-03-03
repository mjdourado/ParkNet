using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ParkNet.Pages.Statistics;

public class StatisticsModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public StatisticsModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Transaction> Transactions { get; set; }
    public decimal Profit { get; set; }

    public async Task<IActionResult> OnGetAsync(DateTime? startDate, DateTime? endDate)
    {
        if (startDate == null || endDate == null)
        {
            return RedirectToPage("./Index");
        }

        Transactions = await _context.Transactions
            .Where(t => t.Date >= startDate && t.Date <= endDate)
            .ToListAsync();

        decimal totalIncome = Transactions
            .Where(t => t.Type == TransactionType.Deposit)
            .Sum(t => t.Amount);

        decimal outcome = Transactions
            .Where(t => t.Type == TransactionType.Withdrawal)
            .Sum(t => t.Amount);

        Profit = totalIncome - outcome;


        return Page();
    }
}
