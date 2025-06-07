using CasoPratico2Models.Models;

namespace CasoPratico2Data.Repositories;

public interface IFilmActorRepository
{
    Task<FilmActor> CreateAsync(FilmActor filmActor);
    Task DeleteAsync(int filmId, int actorId);
    Task<IEnumerable<FilmActor>> GetAllAsync();
    Task<FilmActor?> GetByIdAsync(int filmId, int actorId);
    Task UpdateAsync(FilmActor filmActor);
}