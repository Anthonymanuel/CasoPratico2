using CasoPratico2Data.Context;
using CasoPratico2Models.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CasoPratico2Data.Repositories;

public class FilmCategoryRepository : IFilmCategoryRepository
{
    private readonly SakilaContext _context;

    public FilmCategoryRepository(SakilaContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<FilmCategory>> GetAllAsync()
    {
        return await _context.FilmCategory.ToListAsync();
    }

    public async Task<FilmCategory?> GetByIdAsync(int filmId, int categoryId)
    {
        return await _context.FilmCategory.FindAsync(filmId, categoryId);
    }

    public async Task<FilmCategory> CreateAsync(FilmCategory filmCategory)
    {
        _context.FilmCategory.Add(filmCategory);
        await _context.SaveChangesAsync();
        return filmCategory;
    }

    public async Task UpdateAsync(FilmCategory filmCategory)
    {
        _context.FilmCategory.Update(filmCategory);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int filmId, int categoryId)
    {
        var entity = await GetByIdAsync(filmId, categoryId);
        if (entity != null)
        {
            _context.FilmCategory.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
