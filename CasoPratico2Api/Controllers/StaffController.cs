using CasoPratico2Data.Repositories;
using CasoPratico2Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace CasoPratico2Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StaffController : ControllerBase
{
    private readonly IStaffRepository _staffRepository;
    private readonly ILogger<StaffController> _logger;

    public StaffController(IStaffRepository staffRepository, ILogger<StaffController> logger)
    {
        _staffRepository = staffRepository;
        _logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult> AddStaff([FromBody] Staff staff)
    {
        try
        {
            var created = await _staffRepository.CreateStaffAsync(staff);
            return CreatedAtAction(nameof(GetStaffById), new { id = created.StaffId }, created);
        }
        catch (Exception ex)
        {
            var errorMessage = ex.InnerException?.Message ?? ex.Message;
            _logger.LogError(ex, "Error creating staff");
            return StatusCode(500, new { message = errorMessage });
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateStaff([FromBody] Staff staffToUpdate)
    {
        try
        {
            var existing = await _staffRepository.GetStaffByIdAsync(staffToUpdate.StaffId);
            if (existing == null)
            {
                return NotFound(new { statusCode = 404, message = "Record not found" });
            }

            existing.FirstName = staffToUpdate.FirstName;
            existing.LastName = staffToUpdate.LastName;
            existing.AddressId = staffToUpdate.AddressId;
            existing.Picture = staffToUpdate.Picture;
            existing.Email = staffToUpdate.Email;
            existing.StoreId = staffToUpdate.StoreId;
            existing.Active = staffToUpdate.Active;
            existing.Username = staffToUpdate.Username;
            existing.Password = staffToUpdate.Password;

            await _staffRepository.UpdateStaffAsync(existing);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating staff");
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStaff(int id)
    {
        try
        {
            var existing = await _staffRepository.GetStaffByIdAsync(id);
            if (existing == null)
            {
                return NotFound(new { statusCode = 404, message = "Record not found" });
            }

            await _staffRepository.DeleteStaffAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting staff");
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Staff>>> GetStaff()
    {
        try
        {
            var staffList = await _staffRepository.GetStaffAsync();
            return Ok(staffList);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving staff list");
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStaffById(int id)
    {
        try
        {
            var staff = await _staffRepository.GetStaffByIdAsync(id);
            if (staff == null)
                return NotFound(new { message = "Record not found" });

            return Ok(staff);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving staff by id");
            return StatusCode(500, new { message = ex.Message });
        }
    }
}
