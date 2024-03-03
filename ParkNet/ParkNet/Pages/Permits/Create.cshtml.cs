using Newtonsoft.Json;
using ParkNet.Data.Entities;

namespace ParkNet.Pages.Permits;

public class CreateModel : PageModel
{
    private readonly ParkNet.Data.ApplicationDbContext _context;
    private readonly PermitRepository _permitRepository;

    public CreateModel(ParkNet.Data.ApplicationDbContext context, PermitRepository permitRepository)
    {
        _context = context;
        _permitRepository = permitRepository;
    }

    public async Task<IActionResult> OnGet()
    {
        Permit = new Permit();

        var currentUser = await _context.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);
        var vehicles = await _context.Vehicles
            .Where(v => v.UserId == currentUser.Id)
            .ToListAsync();

        ViewData["VehicleId"] = new SelectList(vehicles, "Id", "Brand");
        ViewData["Parks"] = new SelectList(_context.Parks, "Id", "Name");
        ViewData["PermitType"] = new SelectList(Enum.GetValues(typeof(PermitType)));

        return Page();
    }

    [BindProperty]
    public Permit Permit { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var permitType = Permit.Type;
        var vehicletype = _context.Vehicles.FirstOrDefault(v => v.Id == Permit.VehicleId).Type;

        Permit.Price = (decimal)_permitRepository.PermitPrice(permitType, Permit.VehicleId);
        Permit.EndDate = _permitRepository.GetEndDate(Permit.StartDate, permitType);

        TempData["PermitData"] = JsonConvert.SerializeObject(Permit);

        return RedirectToPage("./SelectFloor", new { Permit.ParkId});
    }
}
