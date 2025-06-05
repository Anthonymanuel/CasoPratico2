using CasoPratico2Models.Models;

namespace CasoPratico2Data.Repositories
{
    public interface IAddressRepository
    {
        Task<Address> CreateAddressAsync(Address address);
        Task DeleteAddressAsync(int id);
        Task<Address?> GetAddressByIdAsync(int id);
        Task<IEnumerable<Address>> GetAddressesAsync();
        Task UpdateAddressAsync(Address address);
    }
}