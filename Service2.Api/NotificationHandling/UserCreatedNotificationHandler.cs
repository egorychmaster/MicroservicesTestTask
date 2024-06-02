using MediatR;
using Newtonsoft.Json;
using Service.Domain.Contracts;

namespace Service2.Api.NotificationHandling
{
    public class UserCreatedNotificationHandler : INotificationHandler<Notification<UserContract>>
    {
        //private readonly DBContext _db;
        private readonly ILogger _logger;

        public UserCreatedNotificationHandler(//DBContext db,
            ILogger<UserCreatedNotificationHandler> logger)
        {
            //_db = db ?? throw new ArgumentNullException(nameof(db));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public virtual async Task Handle(Notification<UserContract> notification,
            CancellationToken cancellationToken)
        {
            try
            {
                var eventContent = notification.Event;





                _logger.LogInformation($"The message was received and stored in the database.\n Content:'{JsonConvert.SerializeObject(eventContent)}'.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Notification '{nameof(notification.Event)}' consumption error.");
            }
        }
    }
}
