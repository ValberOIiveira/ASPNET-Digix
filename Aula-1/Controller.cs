using Microsoft.AspNetCore.Mvc;

namespace aspnet
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello, world!");
        }
    }
}
