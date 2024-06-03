using Microsoft.EntityFrameworkCore;
using Service2.Api.Infrastructure.Services.Interfaces;
using Service2.Domain;
using Service2.Infrastructure.Postgres;

namespace Service2.Api.Infrastructure.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly Service2Context _db;
        public OrganizationService(Service2Context db)
        {
            _db = db;
        }

        public async Task<List<Organization>> GetOrganizations()
        {
            return await _db.Organizations.ToListAsync();
        }
    }
}
