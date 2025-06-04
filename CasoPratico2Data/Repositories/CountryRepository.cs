using CasoPratico2Data.Context;
using CasoPratico2Models.Models;
using Microsoft.EntityFrameworkCore;

namespace CasoPratico2Data.Repositories;

public class CountryRepository : ICountryRepository
{
    private readonly SakilaContext _context;
    public CountryRepository(SakilaContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Country>> GetCountriesAsync()
    {
        var cities = await _context.Country.ToListAsync();

        return cities;
    }

    public async Task<Country> GetCountryByIdAsync(int id)
    {
        return await _context.Country.FindAsync(id);
    }

    public async Task<Country> CreateCountryASync(Country country)
    {
        var createdCountry = _context.Country.Add(country);
        await _context.SaveChangesAsync();
        return country;
    }

    public async Task UpdateCountryAsync(Country country)
    {
        _context.Country.Update(country);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCountryAsync(int id)
    {
        var country = await _context.Country.FindAsync(id);
        _context.Country.Remove(country);
        await _context.SaveChangesAsync();
    }
}
