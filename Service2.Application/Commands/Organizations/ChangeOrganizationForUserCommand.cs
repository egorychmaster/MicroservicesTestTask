using MediatR;

namespace Service2.Application.Commands.Organizations
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
}
