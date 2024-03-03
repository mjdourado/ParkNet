namespace ParkNet.Data.Repositories;

public class OutsRepository
{
    private readonly ParkNet.Data.ApplicationDbContext _context;
    private readonly TicketRepository _ticketRepository;

    public OutsRepository(ParkNet.Data.ApplicationDbContext context, TicketRepository ticketRepository)
    {
        _context = context;
        _ticketRepository = ticketRepository;
    }

    public async Task<Out> OnPostOutsAsync(Ticket ticket)
    {
        var ins = await _context.Ins.FirstOrDefaultAsync(i => i.TicketNumber == ticket.TicketNumber);

        decimal totaltime = _ticketRepository.TotalTime(ins.Enter, DateTime.Now);
        var vehicle = await _context.Vehicles.FirstOrDefaultAsync(v => v.Id == ticket.VehicleId);
        var totalPrice = _ticketRepository.TotalPrice(vehicle.Type, totaltime);

        var parkingSpace = await _context.ParkingSpaces.FirstOrDefaultAsync(ps => ps.Id == ins.ParkingSpaceId);
        parkingSpace.IsFree = true;

        Out outs = new Out
        {
            TicketNumber = ticket.TicketNumber,
            VehicleId = ticket.VehicleId,
            Left = DateTime.Now,
            TotalTime = totaltime,
            TotalPrice = totalPrice
        };

        _context.Outs.Add(outs);
        await _context.SaveChangesAsync();
        return outs;
    }
}


