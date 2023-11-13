using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MCVE
{
    public class TestDbContextFactory : IDesignTimeDbContextFactory<TestDbContext>
    {
        private const string ConfigurationFile = @"appsettings.json";

        public TestDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), ConfigurationFile))
                .AddEnvironmentVariables()
                .Build();

            var builder = new DbContextOptionsBuilder<TestDbContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString, x => x.MigrationsAssembly(typeof(TestDbContextFactory).Assembly.FullName));

            return new TestDbContext(builder.Options);
        }
    }
}
