using CasoPratico2Data.Context;
using CasoPratico2Models.Models;
using Microsoft.EntityFrameworkCore;

namespace CasoPratico2Data.Repositories;

public class StoreRepository : IStoreRepository
{
    private readonly SakilaContext _context;

    public StoreRepository(SakilaContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Store>> GetStoresAsync()
    {
        return await _context.Store.ToListAsync();
    }

    public async Task<Store?> GetStoreByIdAsync(byte id)
    {
        return await _context.Store.FindAsync(id);
    }

    public async Task<Store> CreateStoreAsync(Store store)
    {
        _context.Store.Add(store);
        await _context.SaveChangesAsync();
        return store;
    }

    public async Task UpdateStoreAsync(Store store)
    {
        _context.Store.Update(store);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteStoreAsync(byte id)
    {
        var store = await _context.Store.FindAsync(id);
        if (store != null)
        {
            _context.Store.Remove(store);
            await _context.SaveChangesAsync();
        }
    }
}

