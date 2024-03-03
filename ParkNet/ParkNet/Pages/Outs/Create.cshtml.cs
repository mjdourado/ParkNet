using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ParkNet.Data;
using ParkNet.Data.Entities;
using ParkNet.Data.Repositories;

namespace ParkNet.Pages.Outs
{
    public class CreateModel : PageModel
    {
        private readonly ParkNet.Data.ApplicationDbContext _context;
        private readonly TicketRepository _ticketRepository;

        public CreateModel(ParkNet.Data.ApplicationDbContext context, TicketRepository ticketRepository)
        {
            _context = context;
            _ticketRepository = ticketRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Out Out { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var inData = await _context.Ins.FirstOrDefaultAsync(i => i.TicketNumber == Out.TicketNumber);

            decimal totaltime = _ticketRepository.TotalTime(inData.Enter, DateTime.Now);

            var vehicle = await _context.Vehicles.FirstOrDefaultAsync(v => v.Id == inData.VehicleId);

            var totalPrice = _ticketRepository.TotalPrice(vehicle.Type, totaltime);

            var parkingSpace = await _context.ParkingSpaces.FirstOrDefaultAsync(ps => ps.Id == inData.ParkingSpaceId);
            parkingSpace.IsFree = true;

            Ticket ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.TicketNumber == Out.TicketNumber);
            ticket.IsValid = false;

            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var lastTransaction = _context.Transactions
                .Where(t => t.UserId == currentUserId)
                .OrderByDescending(t => t.Date)
                .FirstOrDefault();

            Transaction transaction = new Transaction
            {
                UserId = currentUserId,
                Date = DateTime.Now,
                Amount = totalPrice,
                Type = TransactionType.Debit,
                InitBalance = lastTransaction.Balance,
                FinalBalance = lastTransaction.FinalBalance - totalPrice,
                Balance = lastTransaction.FinalBalance - totalPrice
            };

            Out currentOut = new Out
            {
                TicketNumber = ticket.TicketNumber,
                VehicleId = ticket.VehicleId,
                Left = DateTime.Now,
                TotalTime = totaltime,
                TotalPrice = totalPrice
            };

            _context.Outs.Add(currentOut);
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
