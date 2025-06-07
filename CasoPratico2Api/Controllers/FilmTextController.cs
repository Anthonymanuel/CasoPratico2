using CasoPratico2Data.Repositories;
using CasoPratico2Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace CasoPratico2Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FilmTextController : ControllerBase
{
    private readonly IFilmTextRepository _filmTextRepository;
    private readonly ILogger<FilmTextController> _logger;

    public FilmTextController(IFilmTextRepository filmTextRepository, ILogger<FilmTextController> logger)
    {
        _filmTextRepository = filmTextRepository;
        _logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult> AddFilmText([FromBody] FilmText filmText)
    {
        try
        {
            var created = await _filmTextRepository.CreateFilmTextAsync(filmText);
            return CreatedAtAction(nameof(GetFilmTextById), new { id = created.FilmId }, created);
        }
        catch (Exception ex)
        {
            var fullError = ex.InnerException?.ToString() ?? ex.ToString();

            _logger.LogError(fullError);

            return StatusCode(StatusCodes.Status500InternalServerError, new
            {
                statusCode = 500,
                message = fullError
            });
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateFilmText([FromBody] FilmText filmText)
    {
        try
        {
            var existing = await _filmTextRepository.GetFilmTextByIdAsync(filmText.FilmId);
            if (existing == null)
                return NotFound(new { message = "Record not found" });

            existing.Title = filmText.Title;
            existing.Description = filmText.Description;

            await _filmTextRepository.UpdateFilmTextAsync(existing);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FilmText>>> GetFilmTexts()
    {
        try
        {
            var films = await _filmTextRepository.GetFilmTextsAsync();
            return Ok(films);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500, new { message = ex.Message });
        }
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFilmText(int id)
    {
        try
        {
            var film = await _filmTextRepository.GetFilmTextByIdAsync(id);
            if (film == null)
                return NotFound(new { message = "Record not found" });

            await _filmTextRepository.DeleteFilmTextAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FilmText>> GetFilmTextById(int id)
    {
        try
        {
            var film = await _filmTextRepository.GetFilmTextByIdAsync(id);
            if (film == null)
                return NotFound(new { message = "Record not found" });

            return Ok(film);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(500, new { message = ex.Message });
        }
    }

}
