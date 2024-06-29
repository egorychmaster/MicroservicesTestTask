using Service2.Domain;
using Service2.Infrastructure.Database;

namespace Service2.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Service2Context _context;

        public UserRepository(Service2Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<User> GetAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public void Add(User item)
        {
            _context.Users.Add(item);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
