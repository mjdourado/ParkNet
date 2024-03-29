﻿namespace ParkNet.Pages.Profile;

[Authorize]
public class CreateModel : PageModel
{
    private readonly ParkNet.Data.ApplicationDbContext _context;

    public CreateModel(ParkNet.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Customer Customer { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        Customer.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        _context.Customers.Add(Customer);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
