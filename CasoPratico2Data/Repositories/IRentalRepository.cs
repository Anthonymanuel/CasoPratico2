using CasoPratico2Models.Models;

namespace CasoPratico2Data.Repositories;

public interface IRentalRepository
{
    Task<Rental> CreateRentalAsync(Rental rental);
    Task DeleteRentalAsync(int id);
    Task<Rental?> GetRentalByIdAsync(int id);
    Task<IEnumerable<Rental>> GetRentalsAsync();
    Task UpdateRentalAsync(Rental rental);
}