using MediatR;
using Microsoft.Extensions.Logging;
using Service2.Domain;
using System.Text.Json;

namespace Service2.Application.Commands.Users
{
    public class UserCreateOrUpdateCommandHandler : IRequestHandler<UserCreateOrUpdateCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger _logger;
        public UserCreateOrUpdateCommandHandler(IUserRepository userRepository, ILogger<UserCreateOrUpdateCommandHandler> logger)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> Handle(UserCreateOrUpdateCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var exist = await _userRepository.GetAsync(command.Id);
                if (exist == null)
                {
                    _userRepository.Add(new User()
                    {
                        Id = command.Id,
                        Name = command.Name,
                        MiddleName = command.MiddleName,
                        Surname = command.Surname,
                        Email = command.Email
                    });
                }
                else
                {
                    exist.Name = command.Name;
                    exist.MiddleName = command.MiddleName;
                    exist.Surname = command.Surname;
                    exist.Email = command.Email;
                }

                await _userRepository.SaveChangesAsync(cancellationToken);

                _logger.LogInformation($"The message was received and stored in the database.\n Content:'{JsonSerializer.Serialize(command)}'.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"The command '{nameof(command)}' completed with an error.");
            }
            
            return true;
        }
    }
}
