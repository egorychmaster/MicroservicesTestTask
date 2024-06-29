using MediatR;
using Service2.Domain;

namespace Service2.Application.Commands.Organizations
{
    public class ChageOrganizationForUserCommandHandler : IRequestHandler<ChangeOrganizationForUserCommand, bool>
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IUserRepository _userRepository;
        public ChageOrganizationForUserCommandHandler(IOrganizationRepository organizationRepository,
            IUserRepository userRepository)
        {
            _organizationRepository = organizationRepository ?? throw new ArgumentNullException(nameof(organizationRepository));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<bool> Handle(ChangeOrganizationForUserCommand command, CancellationToken cancellationToken)
        {
            var organization = await _organizationRepository.GetAsync(command.OrganizationId);
            if (organization == null)
                throw new ArgumentException($"Not found organization #{command.OrganizationId}");

            var user = await _userRepository.GetAsync(command.UserId);
            if (user == null)
                throw new ArgumentException($"Not found user #{command.UserId}");

            user.SetOrganization(organization);

            await _userRepository.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
