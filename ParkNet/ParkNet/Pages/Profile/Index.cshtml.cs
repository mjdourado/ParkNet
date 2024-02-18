using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ParkNet.Data;
using ParkNet.Data.Entities;

namespace ParkNet.Pages.Profile;

[Authorize]
public class IndexModel : PageModel
{
    private readonly ParkNet.Data.ApplicationDbContext _context;

    public IndexModel(ParkNet.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Customer> Customer { get;set; } = default!;

    public async Task OnGetAsync()
    {
        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var customers = _context.Customers.Where(c => c.UserId == currentUserId);
        Customer = await customers.ToListAsync();
    }
}
