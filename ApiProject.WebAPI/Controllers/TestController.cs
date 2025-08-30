using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Test()
        {
            return Ok("Api is working");
        }

        [HttpGet("GetId")]
        public IActionResult test2()
        {
            return Ok("Api 2 is working");
        }
        
    }
}
