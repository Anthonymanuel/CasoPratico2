using CasoPratico2Models.Models;

namespace CasoPratico2Data.Repositories
{
    public interface IInventoryRepository
    {
        Task<Inventory> CreateInventoryAsync(Inventory inventory);
        Task DeleteInventoryAsync(int id);
        Task<IEnumerable<Inventory>> GetInventoriesAsync();
        Task<Inventory?> GetInventoryByIdAsync(int id);
        Task UpdateInventoryAsync(Inventory inventory);
    }
}