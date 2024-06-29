using Service2.Domain.SeedWork;

namespace Service2.Domain
{
    public interface IOrganizationRepository : IRepository
    {
        Task<Organization> GetAsync(int id);
    }
}
