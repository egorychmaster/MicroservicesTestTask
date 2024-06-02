using Microsoft.EntityFrameworkCore;
using Service2.Domain;

namespace Service2.Infrastructure.Postgres
{
    public class Service2Context : DbContext
    {
        public Service2Context(DbContextOptions<Service2Context> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Organization> Organizations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(eb =>
            {
                // Primary key
                eb.HasKey(e => e.Id);

                // Limit the size of columns to use efficient database types

                // Relationships

                // Maps to table
                eb.ToTable("Users");
            });


            modelBuilder.Entity<Organization>(eb =>
            {
                // Primary key
                eb.HasKey(e => e.Id);

                // Maps to table
                eb.ToTable("Organizations");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
