using CasoPratico2Models.Models;

namespace CasoPratico2Data.Repositories;

public interface ICategoryRepository
{
    Task<Category> CreateCategoryAsync(Category category);
    Task DeleteCategoryAsync(int id);
    Task<IEnumerable<Category>> GetCategoriesAsync();
    Task<Category> GetCategoryByIdAsync(int id);
    Task UpdateCategoryAsync(Category category);
}