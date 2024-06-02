using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Service.Contracts;
using Service2.Domain;
using Service2.Infrastructure.Postgres;

namespace Service2.Api.NotificationHandling
{
    public class UserCreatedNotificationHandler : INotificationHandler<Notification<UserContract>>
    {
        private readonly Service2Context _db;
        private readonly ILogger _logger;

        public UserCreatedNotificationHandler(Service2Context db, ILogger<UserCreatedNotificationHandler> logger)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public virtual async Task Handle(Notification<UserContract> notification, CancellationToken cancellationToken)
        {
            try
            {
                UserContract eventUser = notification.Event;

                var exist = await _db.Users.FirstOrDefaultAsync(e => e.Id == eventUser.Number);
                if (exist == null)
                {
                    _db.Users.Add(new User()
                    {
                        Id = eventUser.Number,
                        Name = eventUser.Name,
                        MiddleName = eventUser.MiddleName,
                        Surname = eventUser.Surname,
                        Email = eventUser.Email
                    });

                    await _db.SaveChangesAsync();
                }
                else
                {
                    exist.Name = eventUser.Name;
                    exist.MiddleName = eventUser.MiddleName;
                    exist.Surname = eventUser.Surname;
                    exist.Email = eventUser.Email;

                    await _db.SaveChangesAsync();
                }

                _logger.LogInformation($"The message was received and stored in the database.\n Content:'{JsonConvert.SerializeObject(eventUser)}'.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Notification '{nameof(notification.Event)}' consumption error.");
            }
        }
    }
}
