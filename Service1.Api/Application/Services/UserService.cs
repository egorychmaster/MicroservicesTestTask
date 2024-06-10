using MassTransit;
using Newtonsoft.Json;
using Service.Common.Contracts;
using Service1.Api.Application.DTOs;

namespace Service1.Api.Application.Services
{
    public class UserService : IUserService
    {
        private readonly string _uriBus;
        private readonly IBus _bus;
        private readonly ILogger<UserService> _logger;

        public UserService(IBus bus, ILogger<UserService> logger, string uriBus)
        {
            _uriBus = uriBus ?? throw new ArgumentNullException();
            _bus = bus ?? throw new ArgumentNullException();
            _logger = logger ?? throw new ArgumentNullException();
        }

        public async Task SendToBusAsync(UserDTO user)
        {
            var contract = new UserContract
            {
                Id = user.Id,
                Name = user.Name,
                MiddleName = user.MiddleName,
                Surname = user.Surname,
                Email = user.Email
            };

            // _uriBus = "rabbitmq://rabbitmq/usersQueue"
            Uri uri = new Uri(_uriBus);
            var endPoint = await _bus.GetSendEndpoint(uri);
            await endPoint.Send(contract);

            _logger.LogInformation($"The message has been sent to the bus.\n Content:'{JsonConvert.SerializeObject(contract)}'.");
        }
    }
}
