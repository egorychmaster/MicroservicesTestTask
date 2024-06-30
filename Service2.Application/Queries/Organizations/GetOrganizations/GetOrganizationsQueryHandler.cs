using AutoMapper;
using MediatR;
using Service2.Domain;

namespace Service2.Application.Queries.Organizations.GetOrganizations
{
    public class GetOrganizationsQueryHandler : IRequestHandler<GetOrganizationsQuery, List<OrganizationDTO>>
    {
        private readonly IOrganizationQueriesRepository _organizationQueries;
        private readonly IMapper _mapper;

        public GetOrganizationsQueryHandler(IOrganizationQueriesRepository organizationQueries, IMapper mapper)
        {
            _organizationQueries = organizationQueries;
            _mapper = mapper;
        }

        public async Task<List<OrganizationDTO>> Handle(GetOrganizationsQuery request, CancellationToken cancellationToken)
        {
            var organizations = await _organizationQueries.GetOrganizationsAsync();

            return _mapper.Map<List<Organization>, List<OrganizationDTO>>(organizations);
        }
    }
}
