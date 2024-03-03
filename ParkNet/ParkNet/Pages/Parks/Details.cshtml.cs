using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ParkNet.Data;
using ParkNet.Data.Entities;

namespace ParkNet.Pages.Parks
{
    public class DetailsModel : PageModel
    {
        private readonly ParkNet.Data.ApplicationDbContext _context;

        public DetailsModel(ParkNet.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Park Park { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var park = await _context.Parks.FirstOrDefaultAsync(m => m.Id == id);
            if (park == null)
            {
                return NotFound();
            }
            else
            {
                Park = park;
            }
            return Page();
        }
    }
}
