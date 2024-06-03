using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service2.Api.Application.Models;
using Service2.Api.Application.Queries;

namespace Service2.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<OrganizationsController> _logger;

        public OrganizationsController(IMediator mediator, ILogger<OrganizationsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Получить список всех организаций.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<OrganizationModel>>> Get()
        {
            var query = new GetOrganizationsQuery();
            return await _mediator.Send(query);
        }
    }
}
