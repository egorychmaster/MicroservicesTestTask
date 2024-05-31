using Microsoft.AspNetCore.Mvc;
using Service1.Api.Models;

namespace Service1.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public  IActionResult Post([FromBody]UserInModel user)
        {
            return Ok();
        }
    }
}
