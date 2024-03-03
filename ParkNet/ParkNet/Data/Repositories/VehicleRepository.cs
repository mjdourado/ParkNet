﻿namespace ParkNet.Data.Repositories;

public class VehicleRepository
{
    private readonly ApplicationDbContext _context;

    public VehicleRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Vehicle>> GetAllVehiclesAsync()
    {
        return await _context.Vehicles.ToListAsync();
    }

    public async Task<Vehicle> GetVehicleByIdAsync(int id)
    {
        return await _context.Vehicles.FindAsync(id);
    }

    public async Task <Vehicle> AddVehicleAsync(Vehicle vehicle)
    {
        _context.Vehicles.Add(vehicle);
        await _context.SaveChangesAsync();
        return vehicle;
    }

    public async Task UpdateVehicleAsync(Vehicle vehicle)
    {
        _context.Attach(vehicle).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteVehicleAsync(int id)
    {
        var vehicle = await _context.Vehicles.FirstOrDefaultAsync(v => v.Id == id);
        _context.Vehicles.Remove(vehicle);
        await _context.SaveChangesAsync();
    }
}
