using AutoMapper;
using MediatR;
using Service2.Api.Application.Models;
using Service2.Api.Infrastructure.Services.Interfaces;
using Service2.Domain;

namespace Service2.Api.Application.Queries
{
    public class GetOrganizationsQuery : IRequest<List<OrganizationModel>>
    {
        public GetOrganizationsQuery()
        { }
    }

    public class GetOrganizationQueryHandler : IRequestHandler<GetOrganizationsQuery, List<OrganizationModel>>
    {
        private readonly IOrganizationService _service;
        private readonly IMapper _mapper;
        public GetOrganizationQueryHandler(IOrganizationService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<List<OrganizationModel>> Handle(GetOrganizationsQuery request, CancellationToken cancellationToken)
        {
            var organizations = await _service.GetOrganizations();

            return _mapper.Map<List<Organization>, List<OrganizationModel>>(organizations);
        }
    }
}
