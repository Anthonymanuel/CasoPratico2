using CasoPratico2Data.Repositories;
using CasoPratico2Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace CasoPratico2Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ActorController : ControllerBase
{
    private readonly IActorRepository _actorRepository;
    private readonly ILogger<ActorController> _logger;

    public ActorController(IActorRepository actorRepository, ILogger<ActorController> logger)
    {
        _actorRepository = actorRepository;
        _logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult> AddActor([FromBody] Actor actor)
    {
        try
        {
            var createdActor = await _actorRepository.CreateActorAsync(actor);
            return CreatedAtAction(nameof(GetActorById), new { id = createdActor.ActorId }, createdActor);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateActor([FromBody] Actor actorToUpdate)
    {
        try
        {
            var existingActor = await _actorRepository.GetActorByIdAsync(actorToUpdate.ActorId);
            if (existingActor == null)
            {
                return NotFound(new
                {
                    statusCode = 404,
                    message = "record not found"
                });
            }

            existingActor.FirstName = actorToUpdate.FirstName;
            existingActor.LastName = actorToUpdate.LastName;
            existingActor.LatUpdate = DateTime.Now;

            await _actorRepository.UpdateActorAsync(existingActor);
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
    public async Task<IActionResult> DeleteActor(int id)
    {
        try
        {
            var existingActor = await _actorRepository.GetActorByIdAsync(id);
            if (existingActor == null)
            {
                return NotFound(new
                {
                    statusCode = 404,
                    message = "record not found"
                });
            }

            await _actorRepository.DeleteActorAsync(id);
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
    public async Task<ActionResult<IEnumerable<Actor>>> GetActors()
    {
        try
        {
            var actors = await _actorRepository.GetActorsAsync();
            return Ok(actors);
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
    public async Task<IActionResult> GetActorById(int id)
    {
        try
        {
            var actor = await _actorRepository.GetActorByIdAsync(id);

            if (actor == null)
                return NotFound(new { message = "Record not found" });

            return Ok(actor);
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
