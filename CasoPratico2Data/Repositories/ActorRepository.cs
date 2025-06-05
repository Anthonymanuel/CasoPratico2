using CasoPratico2Data.Context;
using CasoPratico2Models.Models;
using Microsoft.EntityFrameworkCore;

namespace CasoPratico2Data.Repositories;

public class ActorRepository : IActorRepository
{
    private readonly SakilaContext _context;

    public ActorRepository(SakilaContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Actor>> GetActorsAsync()
    {
        return await _context.Actor.ToListAsync();
    }

    public async Task<Actor?> GetActorByIdAsync(int id)
    {
        return await _context.Actor.FindAsync(id);
    }

    public async Task<Actor> CreateActorAsync(Actor actor)
    {
        _context.Actor.Add(actor);
        await _context.SaveChangesAsync();
        return actor;
    }

    public async Task UpdateActorAsync(Actor actor)
    {
        _context.Actor.Update(actor);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteActorAsync(int id)
    {
        var actor = await _context.Actor.FindAsync(id);
        if (actor != null)
        {
            _context.Actor.Remove(actor);
            await _context.SaveChangesAsync();
        }
    }
}
