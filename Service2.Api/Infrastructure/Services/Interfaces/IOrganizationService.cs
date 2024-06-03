using Service2.Domain;

namespace Service2.Api.Infrastructure.Services.Interfaces
{
    public interface IOrganizationService
    {
        Task<List<Organization>> GetOrganizations();
    }
}
