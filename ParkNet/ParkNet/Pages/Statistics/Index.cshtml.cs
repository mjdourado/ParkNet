using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ParkNet.Pages.Statistics;
public class ViewStatistics
{
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public decimal Revenue { get; set; }
}

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }
}
