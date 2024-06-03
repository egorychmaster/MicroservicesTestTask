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
            new User
            {
                Id = 3,
                Name = "Леонардо",
                MiddleName = "",
                Surname = "да Винчи",
                Email = "test_user3@mail.ru",
                OrganizationId = 3,
            },
            new User
            {
                Id = 4,
                Name = "Лев",
                MiddleName = "",
                Surname = "Толстой",
                Email = "lev@mail.ru",
                OrganizationId = 1,
            },
            new User
            {
                Id = 5,
                Name = "Пабло",
                MiddleName = "",
                Surname = "Эскобар",
                Email = "pabloDollars@mail.ru",
                OrganizationId = 4,
            },
            new User
            {
                Id = 6,
                Name = "Стив",
                MiddleName = "",
                Surname = "Джобс",
                Email = "jobs@mail.ru",
                OrganizationId = 5,
            },
            new User
            {
                Id = 7,
                Name = "Иван",
                MiddleName = "Иванович",
                Surname = "Иванов",
                Email = "vanya@mail.ru",
                OrganizationId = 1,
            },
            new User
            {
                Id = 8,
                Name = "Василий",
                MiddleName = "",
                Surname = "Сидоров",
                Email = "sidorow@mail.ru",
                OrganizationId = 4,
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
