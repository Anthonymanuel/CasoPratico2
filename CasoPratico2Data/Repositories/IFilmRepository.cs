using CasoPratico2Models.Models;

namespace CasoPratico2Data.Repositories;

public interface IFilmRepository
{
    Task<Film> CreateFilmAsync(Film film);
    Task DeleteFilmAsync(int id);
    Task<Film?> GetFilmByIdAsync(int id);
    Task<IEnumerable<Film>> GetFilmsAsync();
    Task UpdateFilmAsync(Film film);
}