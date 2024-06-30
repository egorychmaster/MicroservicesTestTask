using Service2.Domain;
using Service2.Infrastructure.Database;

namespace Service2.Infrastructure.Repositories
{
    public class OrganizationCommandsRepository : IOrganizationCommandsRepository
    {
        private readonly Service2Context _context;

        public OrganizationCommandsRepository(Service2Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Organization> GetAsync(int id)
        {
            return await _context.Organizations.FindAsync(id);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
