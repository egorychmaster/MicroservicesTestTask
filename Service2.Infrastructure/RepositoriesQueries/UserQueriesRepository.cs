using Microsoft.EntityFrameworkCore;
using Service2.Application.Queries.Users;
using Service2.Domain;
using Service2.Infrastructure.Database;
using System.Linq.Expressions;

namespace Service2.Infrastructure.RepositoriesQueries
{
    public class UserQueriesRepository : IUserQueriesRepository
    {
        private readonly Service2Context _db;

        public UserQueriesRepository(Service2Context db)
        {
            _db = db;
        }

        public async Task<Tuple<List<User>, int>> GetUsersAsync(
            Expression<Func<User, bool>> wherePredicate, int skip = 0, int take = 5)
        {
            if (wherePredicate == null)
                throw new ArgumentNullException();

            var query = _db.Users
                .Where(wherePredicate)
                .OrderBy(x => x.Id);

            var skipdQuery = query.Skip(skip).Take(take);

            var result = await skipdQuery.AsNoTracking().ToListAsync();
            int count = await query.AsNoTracking().CountAsync();

            return new Tuple<List<User>, int>(result, count);
        }
    }
}
