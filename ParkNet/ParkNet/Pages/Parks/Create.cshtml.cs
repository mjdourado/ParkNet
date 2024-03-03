using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ParkNet.Data;
using ParkNet.Data.Entities;

namespace ParkNet.Pages.Parks
{
    public class CreateModel : PageModel
    {
        private readonly ParkNet.Data.ApplicationDbContext _context;
        private readonly ParkRepository _parkRepository;

        public CreateModel(ParkNet.Data.ApplicationDbContext context, ParkRepository parkRepository)
        {
            _context = context;
            _parkRepository = parkRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Park Park { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _parkRepository.CreatePark(Park);
            return RedirectToPage("./Index");
        }
    }
}
