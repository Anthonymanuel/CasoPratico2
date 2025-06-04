using CasoPratico2Models.Models;

namespace CasoPratico2Data.Repositories
{
    public interface ICityRepository
    {
        Task<City> CreateCityASync(City city);
        Task DeleteCityAsync(int id);
        Task<IEnumerable<City>> GetCitiesAsync();
        Task<City> GetCityByIdAsync(int id);
        Task UpdateCityAsync(City city);
    }
}