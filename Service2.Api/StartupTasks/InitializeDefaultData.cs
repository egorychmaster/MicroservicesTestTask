using Service2.Domain;
using Service2.Infrastructure.Postgres;

namespace Service2.Api.StartupTasks
{
    public class InitializeDefaultData
    {
        public static async Task Initialize(Service2Context db)
        {
            if (db.Organizations.Any())
                return;

            await db.Organizations.AddRangeAsync(Organizations);
            await db.Users.AddRangeAsync(Users);
            await db.SaveChangesAsync();
        }

        private static IEnumerable<User> Users => new List<User>()
        {
            new User
            {
                Id = 1,
                Name = "Вася",
                MiddleName = "Алибабаевич",
                Surname = "Пупкин",
                Email = "vasyaKrut@mail.ru",
                OrganizationId = 1,
            },
            new User
            {
                Id = 2,
                Name = "Анжела",
                MiddleName = "Леонидовна",
                Surname = "Балалайкина",
                Email = "anj@mail.ru",
                OrganizationId = 2,
            },
        };

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
