using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ParkNet.Data;
using ParkNet.Data.Entities;

namespace ParkNet.Pages.Ins
{
    public class IndexModel : PageModel
    {
        private readonly ParkNet.Data.ApplicationDbContext _context;

        public IndexModel(ParkNet.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<In> In { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var ins = _context.Ins
                .Include(i => i.Vehicle)
                .Where(i => i.Vehicle.UserId == currentUserId);

            In = await ins.ToListAsync();
        }
    }
}
