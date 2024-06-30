using Service2.Domain.SeedWork;

namespace Service2.Domain
{
    public interface IOrganizationCommandsRepository : ICommandsRepository
    {
        Task<Organization> GetAsync(int id);
    }
}
