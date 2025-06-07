using CasoPratico2Data.Repositories;
using CasoPratico2Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace CasoPratico2Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StoreController : ControllerBase
{
    private readonly IStoreRepository _storeRepository;
    private readonly ILogger<StoreController> _logger;

    public StoreController(IStoreRepository storeRepository, ILogger<StoreController> logger)
    {
        _storeRepository = storeRepository;
        _logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult> AddStore([FromBody] Store store)
    {
        try
        {
            var createdStore = await _storeRepository.CreateStoreAsync(store);
            return CreatedAtAction(nameof(GetStoreById), new { id = createdStore.StoreId }, createdStore);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al guardar la entidad");

            var baseException = ex.GetBaseException(); // obtiene la raíz del error

            return StatusCode(StatusCodes.Status500InternalServerError, new
            {
                statusCode = 500,
                message = ex.Message,
                innerMessage = baseException.Message,
                stackTrace = ex.StackTrace
            });
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateStore([FromBody] Store storeToUpdate)
    {
        try
        {
            var existingStore = await _storeRepository.GetStoreByIdAsync(storeToUpdate.StoreId);
            if (existingStore == null)
            {
                return NotFound(new
                {
                    statusCode = 404,
                    message = "Record not found"
                });
            }

            existingStore.ManagerStaffId = storeToUpdate.ManagerStaffId;
            existingStore.AddressId = storeToUpdate.AddressId;
            existingStore.LatUpdate = DateTime.Now;

            await _storeRepository.UpdateStoreAsync(existingStore);
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
    public async Task<ActionResult<IEnumerable<Store>>> GetStores()
    {
        try
        {
            var stores = await _storeRepository.GetStoresAsync();
            return Ok(stores);
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
    public async Task<IActionResult> DeleteStore(byte id)
    {
        try
        {
            var existingStore = await _storeRepository.GetStoreByIdAsync(id);
            if (existingStore == null)
            {
                return NotFound(new
                {
                    statusCode = 404,
                    message = "Record not found"
                });
            }

            await _storeRepository.DeleteStoreAsync(id);
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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStoreById(byte id)
    {
        try
        {
            var store = await _storeRepository.GetStoreByIdAsync(id);
            if (store == null)
                return NotFound(new { message = "Record not found" });

            return Ok(store);
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
