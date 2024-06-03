using Service2.Domain;
using Service2.Infrastructure.Postgres;

namespace Service2.Api.StartupTasks
{
    public class InitializeDefaultData
    {
        public static async Task Initialize(Service2Context dbContext)
        {
            if (dbContext.Organizations.Any())
                return;

            await dbContext.Organizations.AddRangeAsync(Organizations);
            await dbContext.SaveChangesAsync();
        }

        private static IEnumerable<Organization> Organizations => new List<Organization>()
        {
            new Organization
            {
                Id = 1,
                Name = "Рога и Копыта"
            },
            new Organization
            {
                Id = 2,
                Name = "Apple",
            },
            new Organization
            {
                Id = 3,
                Name = "Microsoft",
            },
            new Organization
            {
                Id = 4,
                Name = "Adidas",
            },
            new Organization
            {
                Id = 5,
                Name = "Nike",
            },
        };
    }
}
