namespace ParkNet.Data.Repositories;

public class TicketRepository
{
    private readonly ParkNet.Data.ApplicationDbContext _context;

    public TicketRepository(ParkNet.Data.ApplicationDbContext context)
    {
        _context = context;
    }
    
    public decimal TotalTime(DateTime datein, DateTime dateout)
    {
        TimeSpan totaltime = dateout - datein;
        int totalminutes = (int)totaltime.TotalMinutes;
        return totalminutes;
    }

    public string TicketVehicle(int ticketId)
    {
        Ticket ticket = _context.Tickets.Include(t => t.Vehicle).FirstOrDefault(t => t.Id == ticketId);
        return ticket.Vehicle.Type.ToString();
    }

    public decimal TotalPrice(VehicleType vehicle, decimal totalminutes)
    {
        if(totalminutes <= 15)
        {
            return _context.TariffTickets.FirstOrDefault(t => t.Type == vehicle && t.Time == Period.QuarterHourly).Price;
        }
        else if(totalminutes <= 30)
        {
            return _context.TariffTickets.FirstOrDefault(t => t.Type == vehicle && t.Time == Period.HalfHourly).Price;
        }
        else if(totalminutes <= 60)
        {
            return _context.TariffTickets.FirstOrDefault(t => t.Type == vehicle && t.Time == Period.Hourly).Price;
        } else
        {
            return _context.TariffTickets.FirstOrDefault(t => t.Type == vehicle && t.Time == Period.Hourly).Price * (totalminutes / 60);
        }
    }
}