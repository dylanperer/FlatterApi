using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class UtilsController : ControllerBase
{
    [HttpGet(nameof(Ping))]
    public IActionResult Ping()
    {
        return Ok("Ok");
    }
}