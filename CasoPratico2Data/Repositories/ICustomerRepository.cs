using CasoPratico2Models.Models;

namespace CasoPratico2Data.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> CreateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(int id);
        Task<Customer?> GetCustomerByIdAsync(int id);
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task UpdateCustomerAsync(Customer customer);
    }
}