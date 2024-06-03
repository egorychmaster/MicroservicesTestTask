using Microsoft.EntityFrameworkCore;
using Service2.Api.Infrastructure.Services.Interfaces;
using Service2.Domain;
using Service2.Infrastructure.Postgres;
using System.Linq.Expressions;

namespace Service2.Api.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly Service2Context _db;
        public UserService(Service2Context db)
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

            var result = await skipdQuery.ToListAsync();

            int count = await query.CountAsync();

            return new Tuple<List<User>, int>(result, count);
        }
    }
}
