using CasoPratico2Data.Repositories;
using CasoPratico2Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace CasoPratico2Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InventoryController : ControllerBase
{
    private readonly IInventoryRepository _inventoryRepository;
    private readonly ILogger<InventoryController> _logger;

    public InventoryController(IInventoryRepository inventoryRepository, ILogger<InventoryController> logger)
    {
        _inventoryRepository = inventoryRepository;
        _logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult> AddInventory([FromBody] Inventory inventory)
    {
        try
        {
            var created = await _inventoryRepository.CreateInventoryAsync(inventory);
            return CreatedAtAction(nameof(GetInventoryById), new { id = created.InventoryId }, created);
        }
        catch (Exception ex)
        {
            var errorMessage = ex.InnerException?.Message ?? ex.Message;
            _logger.LogError(ex, "Error creating inventory");
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = errorMessage });
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateInventory([FromBody] Inventory inventoryToUpdate)
    {
        try
        {
            var existing = await _inventoryRepository.GetInventoryByIdAsync(inventoryToUpdate.InventoryId);
            if (existing == null)
            {
                return NotFound(new { statusCode = 404, message = "Record not found" });
            }

            existing.FilmId = inventoryToUpdate.FilmId;
            existing.StoreId = inventoryToUpdate.StoreId;
            existing.LatUpdate = DateTime.Now;

            await _inventoryRepository.UpdateInventoryAsync(existing);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating inventory");
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteInventory(int id)
    {
        try
        {
            var existing = await _inventoryRepository.GetInventoryByIdAsync(id);
            if (existing == null)
            {
                return NotFound(new { statusCode = 404, message = "Record not found" });
            }

            await _inventoryRepository.DeleteInventoryAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting inventory");
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Inventory>>> GetInventories()
    {
        try
        {
            var inventories = await _inventoryRepository.GetInventoriesAsync();
            return Ok(inventories);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving inventories");
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetInventoryById(int id)
    {
        try
        {
            var inventory = await _inventoryRepository.GetInventoryByIdAsync(id);
            if (inventory == null)
                return NotFound(new { message = "Record not found" });

            return Ok(inventory);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving inventory by id");
            return StatusCode(500, new { message = ex.Message });
        }
    }
}
