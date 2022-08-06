using BunFooLib.Api.Shared.Repository;
using BunFooLib.Api.Shared.Repository.Contracts;
using Foos.Api.Database.Context;
using Foos.Api.Database.Contracts;
using Foos.Api.Database.Contracts.Entities;
using Foos.Api.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Foos.Api.Database.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDatabaseOperations(this IServiceCollection serviceCollection, IConfiguration configuration, string connectionStringName)
        {
            var connectionString = configuration.GetConnectionString(connectionStringName);
            serviceCollection.AddDbContext<DbContext, FoosDbContext>(options =>
            {
                var version = ServerVersion.AutoDetect(connectionString);
                options.UseMySql(connectionString, version);
            });
            
           //serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<,>));
           serviceCollection.AddScoped<IRepository<FooCategoryEntity>, Repository<FooCategoryEntity, FoosDbContext>>();
           serviceCollection.AddScoped<IRepository<MeasurementEntity>, Repository<MeasurementEntity, FoosDbContext>>();
           serviceCollection.AddScoped<IMeasurementRepository, MeasurementRepository>();
           serviceCollection.AddScoped<IFooCategoryRepository, FooCategoryRepository>();
           serviceCollection.AddScoped<IRecommendedAmountPerDayRepository, RecommendedAmountPerDayRepository>();
           serviceCollection.AddScoped<IFooRepository, FooRepository>();
        }
    }
}
