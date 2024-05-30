using Microsoft.AspNetCore.Mvc;

namespace Service2.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrganizationsController : ControllerBase
    {

        private readonly ILogger<OrganizationsController> _logger;

        public OrganizationsController(ILogger<OrganizationsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public void Get()
        {
        }
    }
}
