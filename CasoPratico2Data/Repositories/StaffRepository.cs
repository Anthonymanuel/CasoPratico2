using CasoPratico2Data.Context;
using CasoPratico2Models.Models;
using Microsoft.EntityFrameworkCore;

namespace CasoPratico2Data.Repositories;

public class StaffRepository : IStaffRepository
{
    private readonly SakilaContext _context;

    public StaffRepository(SakilaContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Staff>> GetStaffAsync()
    {
        return await _context.Staff.ToListAsync();
    }

    public async Task<Staff?> GetStaffByIdAsync(int id)
    {
        return await _context.Staff.FindAsync((byte)id);
    }

    public async Task<Staff> CreateStaffAsync(Staff staff)
    {
        _context.Staff.Add(staff);
        await _context.SaveChangesAsync();
        return staff;
    }

    public async Task UpdateStaffAsync(Staff staff)
    {
        _context.Staff.Update(staff);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteStaffAsync(int id)
    {
        var staff = await _context.Staff.FindAsync((byte)id);
        if (staff != null)
        {
            _context.Staff.Remove(staff);
            await _context.SaveChangesAsync();
        }
    }
}
