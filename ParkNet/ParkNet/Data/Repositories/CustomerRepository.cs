namespace ParkNet.Data.Repositories;

public class CustomerRepository
{
    private readonly ParkNet.Data.ApplicationDbContext _context;

    public CustomerRepository(ParkNet.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Customer>> GetAllCustomersAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task<Customer> GetCustomerByIdAsync(int id)
    {
        return await _context.Customers.FindAsync(id);
    }

    public async Task<Customer> AddCustomerAsync(Customer customer)
    {
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();

        return customer;
    }

    public async Task<Customer> UpdateCustomerAsync(Customer customer)
    {
        _context.Attach(customer).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return customer;
    }

    public async Task DeleteCustomerAsync(int id)
    {
        var customer = await _context.Customers.FirstOrDefaultAsync(t => t.Id == id);
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
    }
}
