using CasoPratico2Models.Models;

namespace CasoPratico2Data.Repositories;

public interface ILanguageRepository
{
    Task<Language> CreateLanguageAsync(Language language);
    Task DeleteLanguageAsync(int id);
    Task<Language> GetLanguageByIdAsync(int id);
    Task<IEnumerable<Language>> GetLanguagesAsync();
    Task UpdateLanguageAsync(Language language);
}