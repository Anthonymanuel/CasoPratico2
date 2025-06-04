using CasoPratico2Models.Models;

namespace CasoPratico2Data.Repositories
{
    public interface ICountryRepository
    {
        Task<Country> CreateCountryASync(Country country);
        Task DeleteCountryAsync(int id);
        Task<IEnumerable<Country>> GetCountriesAsync();
        Task<Country> GetCountryByIdAsync(int id);
        Task UpdateCountryAsync(Country country);
    }
}