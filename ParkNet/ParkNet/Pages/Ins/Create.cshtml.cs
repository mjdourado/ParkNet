using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ParkNet.Data;
using ParkNet.Data.Entities;

namespace ParkNet.Pages.Ins;

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
    public In In { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var currentTicket = _context.Tickets.FirstOrDefault(t => t.TicketNumber == In.TicketNumber);
        In.TicketNumber = currentTicket.TicketNumber;

        var park = await _context.Parks.FirstOrDefaultAsync(p => p.Id == currentTicket.ParkId);

        var vehicle = await _context.Vehicles.FirstOrDefaultAsync(v => v.Id == currentTicket.VehicleId);

        In.VehicleId = vehicle.Id;

        currentTicket.IsValid = false;

        TempData["InData"] = JsonConvert.SerializeObject(In);  

        return RedirectToPage("./SelectFloor", new { currentTicket.ParkId});
    }
}
