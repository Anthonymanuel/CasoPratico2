
using CasoPratico2Data.Context;
using CasoPratico2Models.Models;
using Microsoft.EntityFrameworkCore;

namespace CasoPratico2Data.Repositories;

public class LanguageRepository : ILanguageRepository
{
    private readonly SakilaContext _context;

    public LanguageRepository(SakilaContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Language>> GetLanguagesAsync()
    {
        return await _context.Language.ToListAsync();
    }

    public async Task<Language> GetLanguageByIdAsync(int id)
    {
        return await _context.Language.FindAsync(id);
    }

    public async Task<Language> CreateLanguageAsync(Language language)
    {
        _context.Language.Add(language);
        await _context.SaveChangesAsync();
        return language;
    }

    public async Task UpdateLanguageAsync(Language language)
    {
        _context.Language.Update(language);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteLanguageAsync(int id)
    {
        var language = await _context.Language.FindAsync(id);
        if (language != null)
        {
            _context.Language.Remove(language);
            await _context.SaveChangesAsync();
        }
    }
}

