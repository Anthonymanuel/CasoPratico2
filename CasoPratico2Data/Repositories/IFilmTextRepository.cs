using CasoPratico2Models.Models;

namespace CasoPratico2Data.Repositories
{
    public interface IFilmTextRepository
    {
        Task<FilmText> CreateFilmTextAsync(FilmText filmText);
        Task DeleteFilmTextAsync(int id);
        Task<FilmText?> GetFilmTextByIdAsync(int id);
        Task<IEnumerable<FilmText>> GetFilmTextsAsync();
        Task UpdateFilmTextAsync(FilmText filmText);
    }
}