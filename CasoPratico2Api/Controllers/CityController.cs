using CasoPratico2Data.Repositories;
using CasoPratico2Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace CasoPratico2Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CityController : ControllerBase
{
    private readonly ICityRepository _cityRepository;
    private readonly ILogger<CityController> _logger;
    public CityController(ICityRepository cityRepository, ILogger<CityController> logger)
    {
        _cityRepository = cityRepository;
        _logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult> AddCity([FromBody] City city)
    {
        try
        {
            var createdCity = await _cityRepository.CreateCityASync(city);
            return CreatedAtAction(nameof(GetCityById), new { id = createdCity.CityId }, createdCity);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCity([FromBody] City cityToUpdate)
    {
        try
        {
            var existingCity = await _cityRepository.GetCityByIdAsync(cityToUpdate.CityId);
            if (existingCity == null)
            {
                return NotFound(new
                {
                    statusCode = 404,
                    message = "record not found"
                });
            }
            existingCity.CityName = cityToUpdate.CityName;
            existingCity.CountryId = cityToUpdate.CountryId;
            await _cityRepository.UpdateCityAsync(existingCity);
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
    public async Task<IActionResult> DeleteCity(int id)
    {
        try
        {
            var existingCity = await _cityRepository.GetCityByIdAsync(id);
            if (existingCity == null)
            {
                return NotFound(new
                {
                    statusCode = 404,
                    message = "record not found"
                });
            }

            await _cityRepository.DeleteCityAsync(id);
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
    public async Task<ActionResult<IEnumerable<City>>> GetCities()
    {
        try
        {
            var cities = await _cityRepository.GetCitiesAsync();
            return Ok(cities);
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
    public async Task<IActionResult> GetCityById(int id)
    {
        try
        {
            var city = await _cityRepository.GetCityByIdAsync(id);

            if (city == null)
                return NotFound(new { message = "Record not found" });

            return Ok(city);
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
