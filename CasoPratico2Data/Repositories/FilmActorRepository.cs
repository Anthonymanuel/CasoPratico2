using CasoPratico2Data.Context;
using CasoPratico2Models.Models;
using Microsoft.EntityFrameworkCore;

namespace CasoPratico2Data.Repositories;

public class FilmActorRepository : IFilmActorRepository
{
    private readonly SakilaContext _context;

    public FilmActorRepository(SakilaContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<FilmActor>> GetAllAsync()
    {
        return await _context.FilmActor.ToListAsync();
    }

    public async Task<FilmActor?> GetByIdAsync(int filmId, int actorId)
    {
        return await _context.FilmActor.FindAsync(filmId, actorId);
    }

    public async Task<FilmActor> CreateAsync(FilmActor filmActor)
    {
        _context.FilmActor.Add(filmActor);
        await _context.SaveChangesAsync();
        return filmActor;
    }

    public async Task UpdateAsync(FilmActor filmActor)
    {
        _context.FilmActor.Update(filmActor);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int filmId, int actorId)
    {
        var entity = await GetByIdAsync(filmId, actorId);
        if (entity != null)
        {
            _context.FilmActor.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
