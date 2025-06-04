using CasoPratico2Data.Context;
using CasoPratico2Models.Models;
using Microsoft.EntityFrameworkCore;
namespace CasoPratico2Data.Repositories;

public class CityRepository : ICityRepository
{

    private readonly SakilaContext _context;
    public CityRepository(SakilaContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<City>> GetCitiesAsync()
    {
        var cities = await _context.City.ToListAsync();

        return cities;
    }

    public async Task<City> GetCityByIdAsync(int id)
    {
        return await _context.City.FindAsync(id);
    }

    public async Task<City> CreateCityASync(City city)
    {
        var createdCity = _context.City.Add(city);
        await _context.SaveChangesAsync();
        return city;
    }

    public async Task UpdateCityAsync(City city)
    {
        _context.City.Update(city);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCityAsync(int id)
    {
        var city = await _context.City.FindAsync(id);
        _context.City.Remove(city);
        await _context.SaveChangesAsync();
    }
}
