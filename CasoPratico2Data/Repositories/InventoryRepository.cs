using CasoPratico2Data.Context;
using CasoPratico2Models.Models;
using Microsoft.EntityFrameworkCore;

namespace CasoPratico2Data.Repositories;

public class InventoryRepository : IInventoryRepository
{
    private readonly SakilaContext _context;

    public InventoryRepository(SakilaContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Inventory>> GetInventoriesAsync()
    {
        return await _context.Inventory.ToListAsync();
    }

    public async Task<Inventory?> GetInventoryByIdAsync(int id)
    {
        return await _context.Inventory.FindAsync(id);
    }

    public async Task<Inventory> CreateInventoryAsync(Inventory inventory)
    {
        _context.Inventory.Add(inventory);
        await _context.SaveChangesAsync();
        return inventory;
    }

    public async Task UpdateInventoryAsync(Inventory inventory)
    {
        _context.Inventory.Update(inventory);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteInventoryAsync(int id)
    {
        var inventory = await _context.Inventory.FindAsync(id);
        if (inventory != null)
        {
            _context.Inventory.Remove(inventory);
            await _context.SaveChangesAsync();
        }
    }
}
