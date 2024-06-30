using Microsoft.EntityFrameworkCore;
using Service2.Application.Queries.Organizations;
using Service2.Domain;
using Service2.Infrastructure.Database;

namespace Service2.Infrastructure.RepositoriesQueries
{
    public class OrganizationQueriesRepository : IOrganizationQueriesRepository
    {
        private readonly Service2Context _db;

        public OrganizationQueriesRepository(Service2Context db)
        {
            _db = db;
        }

        public async Task<List<Organization>> GetOrganizationsAsync()
        {
            return await _db.Organizations.AsNoTracking().ToListAsync();
        }
    }
}
