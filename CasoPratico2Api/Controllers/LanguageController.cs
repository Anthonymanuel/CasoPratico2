using CasoPratico2Data.Repositories;
using CasoPratico2Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace CasoPratico2Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LanguageController : ControllerBase
{
    private readonly ILanguageRepository _languageRepository;
    private readonly ILogger<LanguageController> _logger;

    public LanguageController(ILanguageRepository languageRepository, ILogger<LanguageController> logger)
    {
        _languageRepository = languageRepository;
        _logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult> AddLanguage([FromBody] Language language)
    {
        try
        {
            var createdLanguage = await _languageRepository.CreateLanguageAsync(language);
            return CreatedAtAction(nameof(GetLanguageById), new { id = createdLanguage.LanguageId }, createdLanguage);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateLanguage([FromBody] Language languageToUpdate)
    {
        try
        {
            var existingLanguage = await _languageRepository.GetLanguageByIdAsync(languageToUpdate.LanguageId);
            if (existingLanguage == null)
            {
                return NotFound(new
                {
                    statusCode = 404,
                    message = "Record not found"
                });
            }

            existingLanguage.Name = languageToUpdate.Name;
            existingLanguage.LatUpdate = DateTime.Now;
            await _languageRepository.UpdateLanguageAsync(existingLanguage);

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
    public async Task<IActionResult> DeleteLanguage(byte id)
    {
        try
        {
            var existingLanguage = await _languageRepository.GetLanguageByIdAsync(id);
            if (existingLanguage == null)
            {
                return NotFound(new
                {
                    statusCode = 404,
                    message = "Record not found"
                });
            }

            await _languageRepository.DeleteLanguageAsync(id);
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
    public async Task<ActionResult<IEnumerable<Language>>> GetLanguages()
    {
        try
        {
            var languages = await _languageRepository.GetLanguagesAsync();
            return Ok(languages);
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
    public async Task<IActionResult> GetLanguageById(byte id)
    {
        try
        {
            var language = await _languageRepository.GetLanguageByIdAsync(id);

            if (language == null)
                return NotFound(new { message = "Record not found" });

            return Ok(language);
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
