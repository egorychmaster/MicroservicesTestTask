using MediatR;

namespace Service2.Application.Queries.Users.GetUsersFilter
{
    public class GetUsersFilterQuery : IRequest<UserFilterResultDTO>
    {
        public GetUsersFilterQuery(int organizationId, int skip, int take)
        {
            OrganizationId = organizationId;
            Skip = skip;
            Take = take;
        }

        public int OrganizationId { get; }
        public int Skip { get; }
        public int Take { get; }
    }
}
