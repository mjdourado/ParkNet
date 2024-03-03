namespace ParkNet.Data.Repositories;

public class ParkRepository
{
    private readonly ParkNet.Data.ApplicationDbContext _context;

    public List<Floor> Floors { get; set; }

    public ParkRepository(ParkNet.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public void CreatePark(Park park)
    {

        string[] floors = park.ParkLayout.Split(".");
        int currentfloor = 0;
        char currentrow = 'A';

        foreach(string f in floors)
        {
            if(string.IsNullOrEmpty(f))
            {
                continue;
            }
            Floor floor = new Floor
            {
                Name = "Floor" + currentfloor.ToString(),
                ParkingSpaces = new List<ParkingSpace>()
            };
            
            currentfloor++;

            string[] rows = f.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.None);
            foreach(string r in rows)
            {
                char[] spaces = r.ToCharArray();
                int currentspace = 0;
                for(int i = 0; i < spaces.Length; i++)
                {
                    if (spaces[i] == ' ')
                    {
                        continue;
                    }
                    else if (spaces[i] == 'C')
                    {
                        ParkingSpace space = new ParkingSpace
                        {
                            Name = $"{currentrow.ToString()}{currentspace.ToString()}",
                            FloorId = floor.Id,
                            Type = VehicleType.Car
                        };
                        floor.ParkingSpaces.Add(space);
                        currentspace++;
                    }
                    else if (spaces[i] == 'M') 
                    {
                        ParkingSpace space = new ParkingSpace
                        {
                            Name = $"{currentrow.ToString()}{currentspace.ToString()}",
                            FloorId = floor.Id,
                            Type = VehicleType.Motorcycle
                        };
                        floor.ParkingSpaces.Add(space);
                        currentspace++;
                    }
                }
                currentrow++;
            }
            if(park.Floors == null)
            {
                park.Floors = new List<Floor>();
            }
            park.Floors.Add(floor);
        }
        _context.Parks.Add(park);
        _context.SaveChanges();
    }
        

    public async Task<List<Park>> GetAllParksAsync()
    {
        return await _context.Parks.ToListAsync();
    }

    public async Task<Park> GetParkByIdAsync(int id)
    {
        return await _context.Parks.FindAsync(id);
    }

    public async Task<Park> AddParkAsync(Park park)
    {
        _context.Parks.Add(park);
        await _context.SaveChangesAsync();

        return park;
    }

    public async Task<Park> UpdateParkAsync(Park park)
    {
        _context.Attach(park).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return park;
    }

    public async Task DeleteParkAsync(int id)
    {
        var park = await _context.Parks.FirstOrDefaultAsync(p => p.Id == id);
        _context.Parks.Remove(park);
        await _context.SaveChangesAsync();
    }
}
