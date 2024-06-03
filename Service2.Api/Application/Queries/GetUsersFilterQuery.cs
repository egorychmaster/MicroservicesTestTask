using AutoMapper;
using MediatR;
using Service2.Api.Application.Models;
using Service2.Api.Infrastructure.Services.Interfaces;
using Service2.Domain;

namespace Service2.Api.Application.Queries
{
    public class GetUsersFilterQuery : IRequest<UserFilterResult>
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

    public class GetUsersFilterQueryHandler : IRequestHandler<GetUsersFilterQuery, UserFilterResult>
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;
        public GetUsersFilterQueryHandler(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<UserFilterResult> Handle(GetUsersFilterQuery request, CancellationToken cancellationToken)
        {
            var usersTpl = await _service.GetUsersAsync(x => x.OrganizationId == request.OrganizationId,
                skip: request.Skip, take: request.Take);

            var users = _mapper.Map<List<User>, List<UserModel>>(usersTpl.Item1);

            return new UserFilterResult()
            {
                Items = users,
                Skipped = request.Skip,
                Taken = request.Take,
                TotalCount = usersTpl.Item2
            };
        }
    }
}
