using AutoMapper;
using MediatR;
using Service2.Domain;

namespace Service2.Application.Queries.Users.GetUsersFilter
{
    public class GetUsersFilterQueryHandler : IRequestHandler<GetUsersFilterQuery, UserFilterResultDTO>
    {
        private readonly IUserQueriesRepository _userQueries;
        private readonly IMapper _mapper;

        public GetUsersFilterQueryHandler(IUserQueriesRepository userQueries, IMapper mapper)
        {
            _userQueries = userQueries;
            _mapper = mapper;
        }

        public async Task<UserFilterResultDTO> Handle(GetUsersFilterQuery request, CancellationToken cancellationToken)
        {
            var usersTpl = await _userQueries.GetUsersAsync(x => x.OrganizationId == request.OrganizationId,
                skip: request.Skip, take: request.Take);

            var users = _mapper.Map<List<User>, List<UserDTO>>(usersTpl.Item1);

            return new UserFilterResultDTO()
            {
                Items = users,
                Skipped = request.Skip,
                Taken = request.Take,
                TotalCount = usersTpl.Item2
            };
        }
    }
}
