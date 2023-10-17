using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class UtilsController : ControllerBase
{
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpPost(nameof(Ping))]
    public IActionResult Ping()
    {
        return Ok("WTTTTTF");
    }
}