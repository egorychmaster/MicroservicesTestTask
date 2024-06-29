using Microsoft.EntityFrameworkCore;
using Service.Common;
using Service2.Domain;

namespace Service2.Infrastructure.Database
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
                eb.Property(e => e.Name).HasMaxLength(TableFieldsConst.UserFldNameLenght).IsRequired();
                eb.Property(e => e.MiddleName).HasMaxLength(TableFieldsConst.UserFldNameLenght);
                eb.Property(e => e.Surname).HasMaxLength(TableFieldsConst.UserFldNameLenght).IsRequired();
                eb.Property(e => e.Email).HasMaxLength(TableFieldsConst.UserFldFldEmailLenght);                

                // Relationships

                // Maps to table
                eb.ToTable("Users");
            });


            modelBuilder.Entity<Organization>(eb =>
            {
                // Primary key
                eb.HasKey(e => e.Id);

                // Limit the size of columns to use efficient database types
                eb.Property(e => e.Name).HasMaxLength(TableFieldsConst.OrganizationFldNameLenght).IsRequired();

                // Maps to table
                eb.ToTable("Organizations");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
