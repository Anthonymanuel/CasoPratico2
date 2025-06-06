using CasoPratico2Models.Models;

namespace CasoPratico2Data.Repositories
{
    public interface IStaffRepository
    {
        Task<Staff> CreateStaffAsync(Staff staff);
        Task DeleteStaffAsync(int id);
        Task<IEnumerable<Staff>> GetStaffAsync();
        Task<Staff?> GetStaffByIdAsync(int id);
        Task UpdateStaffAsync(Staff staff);
    }
}