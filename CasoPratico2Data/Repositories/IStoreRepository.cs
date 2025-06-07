using CasoPratico2Models.Models;

namespace CasoPratico2Data.Repositories;

public interface IStoreRepository
{
    Task<Store> CreateStoreAsync(Store store);
    Task DeleteStoreAsync(byte id);
    Task<Store?> GetStoreByIdAsync(byte id);
    Task<IEnumerable<Store>> GetStoresAsync();
    Task UpdateStoreAsync(Store store);
}