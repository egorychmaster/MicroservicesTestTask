using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Service2.Application.Mapping;
using Service2.Application.Queries.Users.GetUsersFilter;
using Service2.Domain;
using Service2.Infrastructure.Database;
using Service2.Infrastructure.RepositoriesQueries;

namespace Service2.UnitTest
{
    public class QueryHandlerTest
    {
        private readonly DbContextOptions<Service2Context> _dbOptions;
        private readonly IMapper _mapper;

        public QueryHandlerTest()
        {
            _dbOptions = new DbContextOptionsBuilder<Service2Context>()
                .UseInMemoryDatabase(databaseName: "in-memory")
                .Options;

            using var dbContext = new Service2Context(_dbOptions);
            dbContext.AddRange(GetFakeUser());
            dbContext.SaveChanges();

            MapperConfiguration _config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DomainToDTOProfile>();
            });
            _mapper = _config.CreateMapper();
        }

        [Fact]
        public async Task GetUsersFilterQuery_success()
        {
            //Arrange
            int organizationId = 1;
            int skip = 0;
            int take = 5;
            var totalCount = 3;

            var service2Context = new Service2Context(_dbOptions);
            var _userQueries = new UserQueriesRepository(service2Context);

            //Act
            var _QueryHandler = new GetUsersFilterQueryHandler(_userQueries, _mapper);

            var filterQuery = new GetUsersFilterQuery(organizationId, skip: skip, take: take);
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            UserFilterResultDTO result = await _QueryHandler.Handle(filterQuery, token);

            //Assert
            Assert.IsType<UserFilterResultDTO>(result);
            Assert.Equal(skip, result.Skipped);
            Assert.Equal(take, result.Taken);
            Assert.Equal(totalCount, result.TotalCount);
        }

        private List<User> GetFakeUser()
        {
            return new List<User>()        {
                new()
                {
                    Id = 1,
                    Name = "Вася",
                    MiddleName = "Алибабаевич",
                    Surname = "Пупкин",
                    Email = "vasyaKrut@mail.ru",
                    OrganizationId = 1,
                },
                new()
                {
                    Id = 2,
                    Name = "Анжела",
                    MiddleName = "Леонидовна",
                    Surname = "Балалайкина",
                    Email = "anj@mail.ru",
                    OrganizationId = 2,
                },
                new()
                {
                    Id = 3,
                    Name = "Леонардо",
                    MiddleName = "",
                    Surname = "да Винчи",
                    Email = "test_user3@mail.ru",
                    OrganizationId = 2,
                },
                new()
                {
                    Id = 4,
                    Name = "Лев",
                    MiddleName = "",
                    Surname = "Толстой",
                    Email = "lev@mail.ru",
                    OrganizationId = 1,
                },
                new()
                {
                    Id = 5,
                    Name = "Пабло",
                    MiddleName = "",
                    Surname = "Эскобар",
                    Email = "pabloDollars@mail.ru",
                    OrganizationId = 1,
                }
            };
        }
    }
}