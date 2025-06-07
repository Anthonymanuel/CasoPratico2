using CasoPratico2Data.Context;
using CasoPratico2Models.Models;
using Microsoft.EntityFrameworkCore;

namespace CasoPratico2Data.Repositories;

public class RentalRepository : IRentalRepository
{
    private readonly SakilaContext _context;

    public RentalRepository(SakilaContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Rental>> GetRentalsAsync()
    {
        return await _context.Rental.ToListAsync();
    }

    public async Task<Rental?> GetRentalByIdAsync(int id)
    {
        return await _context.Rental.FindAsync(id);
    }

    public async Task<Rental> CreateRentalAsync(Rental rental)
    {
        _context.Rental.Add(rental);
        await _context.SaveChangesAsync();
        return rental;
    }

    public async Task UpdateRentalAsync(Rental rental)
    {
        _context.Rental.Update(rental);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteRentalAsync(int id)
    {
        var rental = await _context.Rental.FindAsync(id);
        if (rental != null)
        {
            _context.Rental.Remove(rental);
            await _context.SaveChangesAsync();
        }
    }
}
