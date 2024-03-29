﻿namespace ParkNet.Pages.Profile;

[Authorize]
public class EditModel : PageModel
{
    private readonly ParkNet.Data.ApplicationDbContext _context;

    public EditModel(ParkNet.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Customer Customer { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var customer =  await _context.Customers.FirstOrDefaultAsync(m => m.Id == id);
        if (customer == null)
        {
            return NotFound();
        }
        Customer = customer;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        Customer.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        _context.Attach(Customer).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CustomerExists(Customer.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool CustomerExists(int id)
    {
        return _context.Customers.Any(e => e.Id == id);
    }
}
