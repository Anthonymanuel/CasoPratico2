using CasoPratico2Data.Repositories;
using CasoPratico2Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace CasoPratico2Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AddressController : ControllerBase
{
    private readonly IAddressRepository _addressRepository;
    private readonly ILogger<AddressController> _logger;

    public AddressController(IAddressRepository addressRepository, ILogger<AddressController> logger)
    {
        _addressRepository = addressRepository;
        _logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult> AddAddress([FromBody] Address address)
    {
        try
        {
            var created = await _addressRepository.CreateAddressAsync(address);
            return CreatedAtAction(nameof(GetAddressById), new { id = created.AddressId }, created);
        }
        catch (Exception ex)
        {
            var errorMessage = ex.InnerException?.Message ?? ex.Message;
            _logger.LogError(ex, "Error creating Address");
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = errorMessage });
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAddress([FromBody] Address addressToUpdate)
    {
        try
        {
            var existing = await _addressRepository.GetAddressByIdAsync(addressToUpdate.AddressId);
            if (existing == null)
            {
                return NotFound(new { statusCode = 404, message = "Record not found" });
            }

            existing.AddressLine1 = addressToUpdate.AddressLine1;
            existing.AddressLine2 = addressToUpdate.AddressLine2;
            existing.District = addressToUpdate.District;
            existing.CityId = addressToUpdate.CityId;
            existing.PostalCode = addressToUpdate.PostalCode;
            existing.Phone = addressToUpdate.Phone;
            existing.Location = addressToUpdate.Location;
            existing.LatUpdate = DateTime.Now;

            await _addressRepository.UpdateAddressAsync(existing);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating address");
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAddress(int id)
    {
        try
        {
            var existing = await _addressRepository.GetAddressByIdAsync(id);
            if (existing == null)
            {
                return NotFound(new { statusCode = 404, message = "Record not found" });
            }

            await _addressRepository.DeleteAddressAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting address");
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Address>>> GetAddresses()
    {
        try
        {
            var addresses = await _addressRepository.GetAddressesAsync();
            return Ok(addresses);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving addresses");
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAddressById(int id)
    {
        try
        {
            var address = await _addressRepository.GetAddressByIdAsync(id);
            if (address == null)
                return NotFound(new { message = "Record not found" });

            return Ok(address);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving address by id");
            return StatusCode(500, new { message = ex.Message });
        }
    }
}
