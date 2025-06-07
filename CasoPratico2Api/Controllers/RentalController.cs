using CasoPratico2Data.Repositories;
using CasoPratico2Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace CasoPratico2Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RentalController : ControllerBase
{
    private readonly IRentalRepository _rentalRepository;
    private readonly ILogger<RentalController> _logger;

    public RentalController(IRentalRepository rentalRepository, ILogger<RentalController> logger)
    {
        _rentalRepository = rentalRepository;
        _logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult> AddRental([FromBody] Rental rental)
    {
        try
        {
            var createdRental = await _rentalRepository.CreateRentalAsync(rental);
            return CreatedAtAction(nameof(GetRentalById), new { id = createdRental.RentalId }, createdRental);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateRental([FromBody] Rental rentalToUpdate)
    {
        try
        {
            var existingRental = await _rentalRepository.GetRentalByIdAsync(rentalToUpdate.RentalId);
            if (existingRental == null)
            {
                return NotFound(new
                {
                    statusCode = 404,
                    message = "Record not found"
                });
            }

            // Actualiza las propiedades que deseas modificar
            existingRental.RentalDate = rentalToUpdate.RentalDate;
            existingRental.InventoryId = rentalToUpdate.InventoryId;
            existingRental.CustomerId = rentalToUpdate.CustomerId;
            existingRental.ReturnDate = rentalToUpdate.ReturnDate;
            existingRental.StaffId = rentalToUpdate.StaffId;
            existingRental.LatUpdate = DateTime.Now; // Suponiendo que tienes esta propiedad en Rental

            await _rentalRepository.UpdateRentalAsync(existingRental);
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
    public async Task<IActionResult> DeleteRental(int id)
    {
        try
        {
            var existingRental = await _rentalRepository.GetRentalByIdAsync(id);
            if (existingRental == null)
            {
                return NotFound(new
                {
                    statusCode = 404,
                    message = "Record not found"
                });
            }

            await _rentalRepository.DeleteRentalAsync(id);
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
    public async Task<ActionResult<IEnumerable<Rental>>> GetRentals()
    {
        try
        {
            var rentals = await _rentalRepository.GetRentalsAsync();
            return Ok(rentals);
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
    public async Task<IActionResult> GetRentalById(int id)
    {
        try
        {
            var rental = await _rentalRepository.GetRentalByIdAsync(id);

            if (rental == null)
                return NotFound(new { message = "Record not found" });

            return Ok(rental);
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
