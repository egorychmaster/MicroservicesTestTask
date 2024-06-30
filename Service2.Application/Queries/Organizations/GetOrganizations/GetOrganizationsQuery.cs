using MediatR;

namespace Service2.Application.Queries.Organizations.GetOrganizations
{
    public class GetOrganizationsQuery : IRequest<List<OrganizationDTO>>
    {
        public GetOrganizationsQuery()
        { }
    }
}
