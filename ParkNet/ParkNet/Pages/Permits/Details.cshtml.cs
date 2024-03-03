using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ParkNet.Data;
using ParkNet.Data.Entities;

namespace ParkNet.Pages.Permits
{
    public class DetailsModel : PageModel
    {
        private readonly ParkNet.Data.ApplicationDbContext _context;

        public DetailsModel(ParkNet.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Permit Permit { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permit = await _context.Permits
                .Include(p => p.Vehicle)
                .Include(p => p.ParkingSpace)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (permit == null)
            {
                return NotFound();
            }
            else
            {
                Permit = permit;
            }
            return Page();
        }
    }
}
