using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Service2.Infrastructure.Postgres
{
    /// <summary>
    /// Фабрика времени разработки (для миграции Service2Context).
    /// https://stackoverflow.com/questions/60561851/an-error-occurred-while-accessing-the-microsoft-extensions-hosting-services-when
    /// https://learn.microsoft.com/ru-ru/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli
    /// 
    /// 1. Сделать стартовый проект к запуску по умолчанию.
    /// 2. В Package Manager Console выбрать проект DAL
    /// Add-Migration InitialCreate -context Service2Context -o Migrations
    /// </summary>
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<Service2Context>
    {
        public Service2Context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Service2Context>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Service2;Username=postgres;Password=dbpwd");

            return new Service2Context(optionsBuilder.Options);
        }
    }
}
