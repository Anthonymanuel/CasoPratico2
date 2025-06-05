using CasoPratico2Data.Context;
using CasoPratico2Models.Models;
using Microsoft.EntityFrameworkCore;

namespace CasoPratico2Data.Repositories;

public class AddressRepository : IAddressRepository
{
    private readonly SakilaContext _context;

    public AddressRepository(SakilaContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Address>> GetAddressesAsync()
    {
        return await _context.Address.ToListAsync();
    }

    public async Task<Address?> GetAddressByIdAsync(int id)
    {
        return await _context.Address.FindAsync(id);
    }

    public async Task<Address> CreateAddressAsync(Address address)
    {
        _context.Address.Add(address);
        await _context.SaveChangesAsync();
        return address;
    }

    public async Task UpdateAddressAsync(Address address)
    {
        _context.Address.Update(address);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAddressAsync(int id)
    {
        var address = await _context.Address.FindAsync(id);
        if (address is not null)
        {
            _context.Address.Remove(address);
            await _context.SaveChangesAsync();
        }
    }
}
