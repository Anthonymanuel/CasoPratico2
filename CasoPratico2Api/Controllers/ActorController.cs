using CasoPratico2Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace CasoPratico2Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ActorController : ControllerBase
{

    [HttpGet]
    [Route("GetActors")]
    public IActionResult GetActors()
    {
        List<Actor> actors = new List<Actor>
        {
            new Actor { ActorId = 1, FirstName = "John", LastName = "Doe" },
            new Actor { ActorId = 2, FirstName = "Jane", LastName = "Smith" },
            new Actor { ActorId = 3, FirstName = "Bruce", LastName = "Wayne" }
        };

        return Ok(actors);

    }
}
