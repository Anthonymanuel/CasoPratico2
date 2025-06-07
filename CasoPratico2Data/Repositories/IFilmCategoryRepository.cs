using CasoPratico2Models.Models;

namespace CasoPratico2Data.Repositories;

public interface IFilmCategoryRepository
{
    Task<FilmCategory> CreateAsync(FilmCategory filmCategory);
    Task DeleteAsync(int filmId, int categoryId);
    Task<IEnumerable<FilmCategory>> GetAllAsync();
    Task<FilmCategory?> GetByIdAsync(int filmId, int categoryId);
    Task UpdateAsync(FilmCategory filmCategory);
}