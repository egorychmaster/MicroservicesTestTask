using Microsoft.AspNetCore.Mvc;

namespace Service1.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public /*IEnumerable<WeatherForecast>*/ void Get()
        {
            
        }
    }
}
