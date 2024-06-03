using MediatR;
using Microsoft.EntityFrameworkCore;
using Service2.Infrastructure.Postgres;

namespace Service2.Api.Application.Commands
{
    public class ChangeOrganizationForUserCommand : IRequest<bool>
    {
        public ChangeOrganizationForUserCommand(int id, int userId)
        {
            OrganizationId = id;
            UserId = userId;
        }

        public int OrganizationId { get; }
        public int UserId { get; }
    }

    public class ChageOrganizationForUserCommandHandler : IRequestHandler<ChangeOrganizationForUserCommand, bool>
    {
        private readonly Service2Context _db;
        public ChageOrganizationForUserCommandHandler(Service2Context db)
        {
            _db = db;
        }

        public async Task<bool> Handle(ChangeOrganizationForUserCommand command, CancellationToken cancellationToken)
        {
            var organization = await _db.Organizations.SingleOrDefaultAsync(x => x.Id == command.OrganizationId);
            if (organization == null)
                throw new ArgumentException($"Not found organization #{command.OrganizationId}");

            var user = await _db.Users.SingleOrDefaultAsync(x => x.Id == command.UserId);
            if (user == null)
                throw new ArgumentException($"Not found user #{command.UserId}");

            user.SetOrganization(organization);

            await _db.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
