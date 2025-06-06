using CasoPratico2Data.Repositories;
using CasoPratico2Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace CasoPratico2Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FilmCategoryController : ControllerBase
{
    private readonly IFilmCategoryRepository _filmCategoryRepository;
    private readonly ILogger<FilmCategoryController> _logger;

    public FilmCategoryController(IFilmCategoryRepository filmCategoryRepository, ILogger<FilmCategoryController> logger)
    {
        _filmCategoryRepository = filmCategoryRepository;
        _logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult> AddFilmCategory([FromBody] FilmCategory filmCategory)
    {
        try
        {
            var created = await _filmCategoryRepository.CreateAsync(filmCategory);
            return CreatedAtAction(nameof(GetFilmCategoryById), new { filmId = created.FilmId, categoryId = created.CategoryId }, created);
        }
        catch (Exception ex)
        {
            var errorMessage = ex.InnerException?.Message ?? ex.Message;
            _logger.LogError(ex, "Error creating FilmCategory");
            return StatusCode(500, new { message = errorMessage });
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateFilmCategory([FromBody] FilmCategory filmCategoryToUpdate)
    {
        try
        {
            var existing = await _filmCategoryRepository.GetByIdAsync(filmCategoryToUpdate.FilmId, filmCategoryToUpdate.CategoryId);
            if (existing == null)
            {
                return NotFound(new { statusCode = 404, message = "Record not found" });
            }


            await _filmCategoryRepository.UpdateAsync(filmCategoryToUpdate);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating FilmCategory");
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpDelete("{filmId}/{categoryId}")]
    public async Task<IActionResult> DeleteFilmCategory(int filmId, int categoryId)
    {
        try
        {
            var existing = await _filmCategoryRepository.GetByIdAsync(filmId, categoryId);
            if (existing == null)
            {
                return NotFound(new { statusCode = 404, message = "Record not found" });
            }

            await _filmCategoryRepository.DeleteAsync(filmId, categoryId);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting FilmCategory");
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FilmCategory>>> GetFilmCategories()
    {
        try
        {
            var list = await _filmCategoryRepository.GetAllAsync();
            return Ok(list);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving FilmCategories");
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpGet("{filmId}/{categoryId}")]
    public async Task<IActionResult> GetFilmCategoryById(int filmId, int categoryId)
    {
        try
        {
            var entity = await _filmCategoryRepository.GetByIdAsync(filmId, categoryId);
            if (entity == null)
                return NotFound(new { message = "Record not found" });

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving FilmCategory by Ids");
            return StatusCode(500, new { message = ex.Message });
        }
    }
}
