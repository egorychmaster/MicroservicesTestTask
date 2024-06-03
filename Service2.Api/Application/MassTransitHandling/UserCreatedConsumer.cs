using MassTransit;
using MediatR;
using Service.Contracts;
using Service2.Api.Application.NotificationHandling;

namespace Service2.Api.Application.MassTransitHandling
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
