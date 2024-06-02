using MassTransit;
using MediatR;
using Service.Domain.Contracts;
using Service2.Api.NotificationHandling;

namespace Service2.Api.Consumers
{
    public class UserCreatedConsumer : IConsumer<UserContract>
    {
        private readonly IMediator _mediator;

        public UserCreatedConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<UserContract> context)
        {
            var @event = new Notification<UserContract>(context.Message);
            await _mediator.Publish(@event);
        }
    }
}
