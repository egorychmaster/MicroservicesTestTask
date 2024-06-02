using MediatR;

namespace Service2.Api.NotificationHandling
{
    public class Notification<T> : INotification
    {
        public Notification(T @event)
        {
            Event = @event;
        }

        public T Event { get; }
    }
}
