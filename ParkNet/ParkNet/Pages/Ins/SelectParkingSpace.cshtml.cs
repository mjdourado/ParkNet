using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace ParkNet.Pages.Ins;

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
        var inDataJson = TempData["InData"] as string;
        var inData = JsonConvert.DeserializeObject<In>(inDataJson);

        var vehicleType = _context.Vehicles
            .Where(v => v.Id == inData.VehicleId)
            .Select(v => v.Type)
            .FirstOrDefault();

        var parkingSpaces = _context.ParkingSpaces
            .Where(p => p.FloorId == selectedFloorId)
            .Where(p => p.IsFree)
            .Where(p => p.Type == vehicleType)
            .ToList();

        ViewData["ParkingSpaces"] = new SelectList(parkingSpaces, "Id", "Name");

        TempData["InData"] = JsonConvert.SerializeObject(inData);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var inDataJson = TempData["InData"] as string;
        var inData = JsonConvert.DeserializeObject<In>(inDataJson);

        inData.ParkingSpaceId = SelectedParkingSpaceId;

        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var lastTransaction = _context.Transactions
            .Where(t => t.UserId == currentUserId)
            .OrderByDescending(t => t.Date)
            .FirstOrDefault();

        var parkingSpace = _context.ParkingSpaces
            .Where(p => p.Id == SelectedParkingSpaceId)
            .FirstOrDefault();
        parkingSpace.IsFree = false;

        _context.Ins.Add(inData);
        await _context.SaveChangesAsync();

        TempData.Remove("InData");

        return RedirectToPage("./Index");
    }
}
