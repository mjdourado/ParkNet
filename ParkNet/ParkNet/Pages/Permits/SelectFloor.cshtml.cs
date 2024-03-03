using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ParkNet.Pages.Permits;

public class SelectFloorModel : PageModel
{
    private readonly ParkNet.Data.ApplicationDbContext _context;

    public SelectFloorModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public int SelectedFloorId { get; set; }

    public void OnGet(int parkId)
    {
        var floors = _context.Floors
            .Where(f => f.ParkId == parkId)
            .ToList();

        ViewData["Floors"] = new SelectList(floors, "Id", "Name");
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        return RedirectToPage("./SelectParkingSpace", new {SelectedFloorId});
    }
}
