using CasoPratico2Data.Context;
using CasoPratico2Models.Models;
using Microsoft.EntityFrameworkCore;

namespace CasoPratico2Data.Repositories;

public class FilmRepository : IFilmRepository
{
    private readonly SakilaContext _context;

    public FilmRepository(SakilaContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Film>> GetFilmsAsync()
    {
        return await _context.Film.ToListAsync();
    }

    public async Task<Film?> GetFilmByIdAsync(int id)
    {
        return await _context.Film.FindAsync(id);
    }

    public async Task<Film> CreateFilmAsync(Film film)
    {
        _context.Film.Add(film);
        await _context.SaveChangesAsync();
        return film;
    }

    public async Task UpdateFilmAsync(Film film)
    {
        _context.Film.Update(film);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteFilmAsync(int id)
    {
        var film = await _context.Film.FindAsync(id);
        if (film != null)
        {
            _context.Film.Remove(film);
            await _context.SaveChangesAsync();
        }
    }
}
