using Service2.Domain;

namespace Service2.Application.Queries.Organizations
{
    public interface IOrganizationQueriesRepository
    {
        Task<List<Organization>> GetOrganizationsAsync();
    }
}
