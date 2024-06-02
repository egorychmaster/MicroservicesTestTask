using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Service.Domain;
using Service.Domain.Contracts;
using Service1.Api.Models;

namespace Service1.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IBus _bus;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IBus bus, ILogger<UsersController> logger)
        {
            _bus = bus;
            _logger = logger;
        }

        [HttpPost]
        public  async Task<IActionResult> Post([FromBody]UserInModel user)
        {
            var contract = new UserContract
            {
                Number = user.Number,
                Name = user.Name,
                MiddleName = user.MiddleName,
                Surname = user.Surname,
                Email = user.Email
            };

            Uri uri = new Uri(RabbitMqConsts.RabbitMqUri);
            var endPoint = await _bus.GetSendEndpoint(uri);
            await endPoint.Send(contract);
            //await _bus.Publish(contract);

            _logger.LogInformation($"The message has been sent to the bus.\n Content:'{JsonConvert.SerializeObject(contract)}'.");
            return Ok();
        }
    }
}
