using Microsoft.AspNetCore.Mvc;

namespace Todo.Controllers;

[Route("api/todo")]
[ApiController]
public class TodoController: ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
}