using CasoPratico2Data.Repositories;
using CasoPratico2Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace CasoPratico2Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FilmController : ControllerBase
{
    private readonly IFilmRepository _filmRepository;
    private readonly ILogger<FilmController> _logger;

    public FilmController(IFilmRepository filmRepository, ILogger<FilmController> logger)
    {
        _filmRepository = filmRepository;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Film>>> GetFilms()
    {
        try
        {
            var films = await _filmRepository.GetFilmsAsync();
            return Ok(films);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving films");
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Film>> GetFilmById(int id)
    {
        try
        {
            var film = await _filmRepository.GetFilmByIdAsync(id);
            if (film == null)
                return NotFound(new { message = "Record not found" });

            return Ok(film);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving film by id");
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpPost]
    public async Task<ActionResult> AddFilm([FromBody] Film film)
    {
        try
        {
            var created = await _filmRepository.CreateFilmAsync(film);
            return CreatedAtAction(nameof(GetFilmById), new { id = created.FilmId }, created);
        }
        catch (Exception ex)
        {
            var fullError = ex.InnerException?.ToString() ?? ex.ToString();
            _logger.LogError(fullError);
            return StatusCode(500, new { message = fullError });
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateFilm([FromBody] Film film)
    {
        try
        {
            var existing = await _filmRepository.GetFilmByIdAsync(film.FilmId);
            if (existing == null)
                return NotFound(new { message = "Record not found" });

            existing.Title = film.Title;
            existing.Description = film.Description;
            existing.ReleaseYear = film.ReleaseYear;
            existing.LanguageId = film.LanguageId;
            existing.OriginalLanguageId = film.OriginalLanguageId;
            existing.RentalDuration = film.RentalDuration;
            existing.RentalRate = film.RentalRate;
            existing.Length = film.Length;
            existing.ReplacementCost = film.ReplacementCost;
            existing.Rating = film.Rating;
            existing.SpecialFeatures = film.SpecialFeatures;

            await _filmRepository.UpdateFilmAsync(existing);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating film");
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFilm(int id)
    {
        try
        {
            var film = await _filmRepository.GetFilmByIdAsync(id);
            if (film == null)
                return NotFound(new { message = "Record not found" });

            await _filmRepository.DeleteFilmAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting film");
            return StatusCode(500, new { message = ex.Message });
        }
    }
}
