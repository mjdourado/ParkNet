﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly ParkNet.Data.ApplicationDbContext _context;

        public DeleteModel(ParkNet.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var park = await _context.Parks.FindAsync(id);
            if (park != null)
            {
                Park = park;
                _context.Parks.Remove(Park);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
