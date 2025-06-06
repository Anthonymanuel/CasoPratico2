using CasoPratico2Data.Repositories;
using CasoPratico2Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace CasoPratico2Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FilmActorController : ControllerBase
{
    private readonly IFilmActorRepository _filmActorRepository;
    private readonly ILogger<FilmActorController> _logger;

    public FilmActorController(IFilmActorRepository filmActorRepository, ILogger<FilmActorController> logger)
    {
        _filmActorRepository = filmActorRepository;
        _logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult> AddFilmActor([FromBody] FilmActor filmActor)
    {
        try
        {
            var created = await _filmActorRepository.CreateAsync(filmActor);
            return CreatedAtAction(nameof(GetFilmActorById), new { filmId = created.FilmId, actorId = created.ActorId }, created);
        }
        catch (Exception ex)
        {
            var errorMessage = ex.InnerException?.Message ?? ex.Message;
            _logger.LogError(ex, "Error creating FilmActor");
            return StatusCode(500, new { message = errorMessage });
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateFilmActor([FromBody] FilmActor filmActorToUpdate)
    {
        try
        {
            var existing = await _filmActorRepository.GetByIdAsync(filmActorToUpdate.FilmId, filmActorToUpdate.ActorId);
            if (existing == null)
            {
                return NotFound(new { statusCode = 404, message = "Record not found" });
            }

            await _filmActorRepository.UpdateAsync(filmActorToUpdate);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating FilmActor");
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpDelete("{filmId}/{actorId}")]
    public async Task<IActionResult> DeleteFilmActor(int filmId, int actorId)
    {
        try
        {
            var existing = await _filmActorRepository.GetByIdAsync(filmId, actorId);
            if (existing == null)
            {
                return NotFound(new { statusCode = 404, message = "Record not found" });
            }

            await _filmActorRepository.DeleteAsync(filmId, actorId);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting FilmActor");
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FilmActor>>> GetFilmActors()
    {
        try
        {
            var list = await _filmActorRepository.GetAllAsync();
            return Ok(list);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving FilmActors");
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpGet("{filmId}/{actorId}")]
    public async Task<IActionResult> GetFilmActorById(int filmId, int actorId)
    {
        try
        {
            var entity = await _filmActorRepository.GetByIdAsync(filmId, actorId);
            if (entity == null)
                return NotFound(new { message = "Record not found" });

            return Ok(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving FilmActor by Ids");
            return StatusCode(500, new { message = ex.Message });
        }
    }
}
