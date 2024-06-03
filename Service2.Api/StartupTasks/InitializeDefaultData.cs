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
            new()
            {
                Id = 1,
                Name = "Вася",
                MiddleName = "Алибабаевич",
                Surname = "Пупкин",
                Email = "vasyaKrut@mail.ru",
                OrganizationId = 1,
            },
            new()
            {
                Id = 2,
                Name = "Анжела",
                MiddleName = "Леонидовна",
                Surname = "Балалайкина",
                Email = "anj@mail.ru",
                OrganizationId = 2,
            },
            new()
            {
                Id = 3,
                Name = "Леонардо",
                MiddleName = "",
                Surname = "да Винчи",
                Email = "test_user3@mail.ru",
                OrganizationId = 2,
            },
            new()
            {
                Id = 4,
                Name = "Лев",
                MiddleName = "",
                Surname = "Толстой",
                Email = "lev@mail.ru",
                OrganizationId = 2,
            },
            new()
            {
                Id = 5,
                Name = "Пабло",
                MiddleName = "",
                Surname = "Эскобар",
                Email = "pabloDollars@mail.ru",
                OrganizationId = 4,
            },
            new()
            {
                Id = 6,
                Name = "Стив",
                MiddleName = "",
                Surname = "Джобс",
                Email = "jobs@mail.ru",
                OrganizationId = 5,
            },
            new()
            {
                Id = 7,
                Name = "Иван",
                MiddleName = "Иванович",
                Surname = "Иванов",
                Email = "vanya@mail.ru",
                OrganizationId = 2,
            },
            new()
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
            new()
            {
                Id = 1,
                Name = "Рога и Копыта"
            },
            new()
            {
                Id = 2,
                Name = "Apple",
            },
            new()
            {
                Id = 3,
                Name = "Microsoft",
            },
            new()
            {
                Id = 4,
                Name = "Adidas",
            },
            new()
            {
                Id = 5,
                Name = "Nike",
            },
        };
    }
}
