using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Foos.Api.Database.Context
{
    public class FoosDbContextFactory: IDesignTimeDbContextFactory<FoosDbContext>
    {
        public FoosDbContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, false);
            
            var configuration = builder.Build();
            
            var connectionString = configuration.GetConnectionString("FoosDbConnectionString");
            var options = new DbContextOptionsBuilder();
            var version = ServerVersion.AutoDetect(connectionString);
            options.UseMySql(connectionString, version);

            return new FoosDbContext(options.Options);
        }
    }
}
