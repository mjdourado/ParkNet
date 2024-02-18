using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ParkNet.Data;
using ParkNet.Data.Entities;

namespace ParkNet.Pages.Prices.TariffsPermits
{
    public class DeleteModel : PageModel
    {
        private readonly ParkNet.Data.ApplicationDbContext _context;

        public DeleteModel(ParkNet.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tariffpermit = await _context.TariffPermits.FindAsync(id);
            if (tariffpermit != null)
            {
                TariffPermit = tariffpermit;
                _context.TariffPermits.Remove(TariffPermit);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
