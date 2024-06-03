using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service2.Api.Application.Commands;
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
        /// ѕолучить список всех организаций.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<OrganizationModel>>> Get()
        {
            var query = new GetOrganizationsQuery();
            return await _mediator.Send(query);
        }

        /// <summary>
        /// ¬ернуть пользователей с пагинацией по организации.
        /// </summary>
        /// <returns></returns>
        [HttpPost("/{id}/Users/Filter")]
        public async Task<ActionResult<UserFilterResult>> GetUsersByOrganization(int id, [FromBody] PagingInModel model)
        {
            var query = new GetUsersFilterQuery(id, skip: model.Skip, take: model.Take);
            return await _mediator.Send(query);
        }

        /// <summary>
        /// —в€зать пользовател€ с организацией.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost("{id}/User/{userId}")]
        public async Task<ActionResult> ChageOrganizationForUser(int id, int userId)
        {
            var command = new ChageOrganizationForUserCommand(id, userId);
            var result = await _mediator.Send(command);
            return Ok();
        }
    }
}
