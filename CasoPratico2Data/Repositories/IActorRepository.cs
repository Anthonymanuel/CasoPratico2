using CasoPratico2Models.Models;

namespace CasoPratico2Data.Repositories;

public interface IActorRepository
{
    Task<Actor> CreateActorAsync(Actor actor);
    Task DeleteActorAsync(int id);
    Task<Actor?> GetActorByIdAsync(int id);
    Task<IEnumerable<Actor>> GetActorsAsync();
    Task UpdateActorAsync(Actor actor);
}