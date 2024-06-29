using Service2.Domain.SeedWork;

namespace Service2.Domain
{
    public interface IUserRepository : IRepository
    {
        Task<User> GetAsync(int id);

        void Add(User item);
    }
}
