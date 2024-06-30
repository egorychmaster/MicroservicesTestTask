using Service2.Domain;
using System.Linq.Expressions;

namespace Service2.Application.Queries.Users
{
    public interface IUserQueriesRepository
    {
        /// <summary>
        /// Вернуть список пользователей с пагинацией.
        /// </summary>
        /// <param name="wherePredicate"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        Task<Tuple<List<User>, int>> GetUsersAsync(
            Expression<Func<User, bool>> wherePredicate, int skip = 0, int take = 5);
    }
}
