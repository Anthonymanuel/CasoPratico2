using CasoPratico2Data.Context;
using CasoPratico2Models.Models;
using Microsoft.EntityFrameworkCore;

namespace CasoPratico2Data.Repositories;

public class FilmTextRepository : IFilmTextRepository
{
    private readonly SakilaContext _context;

    public FilmTextRepository(SakilaContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<FilmText>> GetFilmTextsAsync()
    {
        return await _context.FilmText.ToListAsync();
    }

    public async Task<FilmText?> GetFilmTextByIdAsync(int id)
    {
        return await _context.FilmText.FindAsync(id);
    }

    public async Task<FilmText> CreateFilmTextAsync(FilmText filmText)
    {
        _context.FilmText.Add(filmText);
        await _context.SaveChangesAsync();
        return filmText;
    }

    public async Task UpdateFilmTextAsync(FilmText filmText)
    {
        _context.FilmText.Update(filmText);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteFilmTextAsync(int id)
    {
        var filmText = await _context.FilmText.FindAsync(id);
        if (filmText != null)
        {
            _context.FilmText.Remove(filmText);
            await _context.SaveChangesAsync();
        }
    }
}
