using BunFooLib.Api.Shared.Repository.Contracts;
using Foos.Api.Database.Contracts.Entities;
using Foos.Api.Operation.Contracts;
using Foos.Api.Operations.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Foos.Api.Operations.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddOperations(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IMeasurementService, MeasurementService>();
            serviceCollection.AddTransient<IFooCategoryService, FooCategoryService>();
        }
    }
}
