using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace ParkNet.Pages.Permits;

public class SelectParkingSpaceModel : PageModel
{
    private readonly ParkNet.Data.ApplicationDbContext _context;

    public SelectParkingSpaceModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public int SelectedParkingSpaceId { get; set; }

    public void OnGet(int selectedFloorId)
    {
        var permitDataJson = TempData["PermitData"] as string;
        var permit = JsonConvert.DeserializeObject<Permit>(permitDataJson);

        var vehicleType = _context.Vehicles
            .Where(v => v.Id == permit.VehicleId)
            .Select(v => v.Type)
            .FirstOrDefault();

        var parkingSpaces = _context.ParkingSpaces
            .Where(p => p.FloorId == selectedFloorId)
            .Where(p => p.IsFree)
            .Where(p => p.Type == vehicleType)
            .ToList();

        ViewData["ParkingSpaces"] = new SelectList(parkingSpaces, "Id", "Name");

        TempData["PermitData"] = JsonConvert.SerializeObject(permit);
    }

    public async Task<IActionResult> OnPostAsync(int selectedfloorId)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var permitDataJson = TempData["PermitData"] as string;
        var permit = JsonConvert.DeserializeObject<Permit>(permitDataJson);

        permit.ParkingSpaceId = SelectedParkingSpaceId;
        permit.FloorId = selectedfloorId;

        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var lastTransaction = _context.Transactions
            .Where(t => t.UserId == currentUserId)
            .OrderByDescending(t => t.Date)
            .FirstOrDefault();

        var parkingSpace = _context.ParkingSpaces
            .Where(p => p.Id == SelectedParkingSpaceId)
            .FirstOrDefault();

        parkingSpace.IsFree = false;

        var transaction = new Transaction
        {
            UserId = currentUserId,
            Amount = permit.Price,
            Date = DateTime.Now,
            Type = TransactionType.Debit,
            InitBalance = lastTransaction.FinalBalance,
            FinalBalance = lastTransaction.FinalBalance - permit.Price,
            Balance = lastTransaction.FinalBalance - permit.Price
        };

        _context.Permits.Add(permit);
        _context.Transactions.Add(transaction);
        await _context.SaveChangesAsync();

        TempData.Remove("PermitData");

        return RedirectToPage("/permits/Index");
    }
}
