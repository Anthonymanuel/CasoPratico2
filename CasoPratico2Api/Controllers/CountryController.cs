using CasoPratico2Data.Repositories;
using CasoPratico2Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace CasoPratico2Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountryController : ControllerBase
{
    private readonly ICountryRepository _countryRepository;
    private readonly ILogger<CountryController> _logger;
    public CountryController(ICountryRepository countryRepository, ILogger<CountryController> logger)
    {
        _countryRepository = countryRepository;
        _logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult> AddCountry([FromBody] Country country)
    {
        try
        {
            var createdCountry = await _countryRepository.CreateCountryASync(country);
            return CreatedAtAction(nameof(GetCountryById), new { id = createdCountry.CountryId }, createdCountry);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCountry([FromBody] Country countryToUpdate)
    {
        try
        {
            var existingCountry = await _countryRepository.GetCountryByIdAsync(countryToUpdate.CountryId);
            if (existingCountry == null)
            {
                return NotFound(new
                {
                    statusCode = 404,
                    message = "record not found"
                });
            }
            existingCountry.Name = countryToUpdate.Name;
            existingCountry.LatUpdate = DateTime.Now;
            await _countryRepository.UpdateCountryAsync(existingCountry);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, new
            {
                statusCode = 500,
                message = ex.Message
            });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCountry(int id)
    {
        try
        {
            var existingCity = await _countryRepository.GetCountryByIdAsync(id);
            if (existingCity == null)
            {
                return NotFound(new
                {
                    statusCode = 404,
                    message = "record not found"
                });
            }

            await _countryRepository.DeleteCountryAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, new
            {
                statusCode = 500,
                message = ex.Message
            });
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
    {
        try
        {
            var countries = await _countryRepository.GetCountriesAsync();
            return Ok(countries);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, new
            {
                statusCode = 500,
                message = ex.Message
            });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCountryById(int id)
    {
        try
        {
            var country = await _countryRepository.GetCountryByIdAsync(id);

            if (country == null)
                return NotFound(new { message = "Record not found" });

            return Ok(country);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, new
            {
                statusCode = 500,
                message = ex.Message
            });
        }
    }
}
