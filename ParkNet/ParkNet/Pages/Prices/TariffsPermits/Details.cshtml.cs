using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ParkNet.Data;
using ParkNet.Data.Entities;

namespace ParkNet.Pages.Prices.TariffsPermits;

[Authorize]
public class DetailsModel : PageModel
{
    private readonly ParkNet.Data.ApplicationDbContext _context;

    public DetailsModel(ParkNet.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public TariffPermit TariffPermit { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var tariffpermit = await _context.TariffPermits.FirstOrDefaultAsync(m => m.Id == id);
        if (tariffpermit == null)
        {
            return NotFound();
        }
        else
        {
            TariffPermit = tariffpermit;
        }
        return Page();
    }
}
