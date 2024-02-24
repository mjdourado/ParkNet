namespace ParkNet.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Park> Parks { get; set; }
    public DbSet<Floor> Floors { get; set; }
    public DbSet<ParkingSpace> ParkingSpaces { get; set; }
    public DbSet<Permit> Permits { get; set; }
    public DbSet<TariffPermit> TariffPermits { get; set; }
    public DbSet<TariffTicket> TariffTickets { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Ins> Ins { get; set; }
    public DbSet<Outs> Outs { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    { 
    }
}