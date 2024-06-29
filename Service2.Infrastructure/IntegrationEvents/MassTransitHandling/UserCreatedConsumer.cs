using MassTransit;
using MediatR;
using Service.Common.Contracts;
using Service2.Application.Commands.Users;

namespace Service2.Api.IntegrationEvents.MassTransitHandling
{
    /// <summary>
    /// Получаем контракт пользователя по шине из RabbitMq.
    /// </summary>
    public class UserCreatedConsumer : IConsumer<UserContract>
    {
        private readonly IMediator _mediator;

        public UserCreatedConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<UserContract> context)
        {
            // Командой добавляем или обновляем пользователя.
            var command = new UserCreateOrUpdateCommand(
                id: context.Message.Id, 
                name: context.Message.Name,
                middleName: context.Message.MiddleName,
                surname: context.Message.Surname,
                email: context.Message.Email
                );

            await _mediator.Send(command);
        }
    }
}
