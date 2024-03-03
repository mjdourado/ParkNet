namespace ParkNet.Pages.Tickets;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var vehicles = _context.Vehicles
            .Where(v => v.UserId == currentUserId)
            .ToList();
        ViewData["vehicleId"] = new SelectList(vehicles, "Id", "Brand");
        ViewData["parkId"] = new SelectList(_context.Parks, "Id", "Name");

        return Page();
    }

    [BindProperty]
    public Ticket Ticket { get; set; } = default!;

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var radom = new Random();
        Ticket.TicketNumber = radom.Next(100000, 999999);
        Ticket.IsValid = true;

        _context.Tickets.Add(Ticket);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
