using MCVE.Entities;

using Microsoft.EntityFrameworkCore;

namespace MCVE
{
    public class TestDbContext : DbContext
    {
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Option> Options { get; set; }

        public TestDbContext(DbContextOptions<TestDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // First Run 
            // 'dotnet ef migrations add Initial --verbose'
            // With this code 

            builder.Entity<Ticket>(
                typeBuilder =>
                    {
                        typeBuilder.HasMany(o => o.Options).WithOne().IsRequired().OnDelete(DeleteBehavior.Restrict);

                    });

            builder.Entity<Option>(
                typeBuilder =>
                    {
                        typeBuilder.HasOne(o => o.Ticket).WithMany(organizationGroup => organizationGroup.Options).HasForeignKey(c => c.TicketId);
                    });

            // Next comment out the builder logic above and uncomment the logic below and Run
            // 'dotnet ef migrations add Second --verbose'

            //builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}