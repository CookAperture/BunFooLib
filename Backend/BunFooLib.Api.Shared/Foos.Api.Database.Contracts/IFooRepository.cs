using BunFooLib.Api.Shared.Repository.Contracts;
using Foos.Api.Database.Contracts.Entities;

namespace Foos.Api.Database.Contracts
{
    public interface IFooRepository : IRepository<FooEntity>
    {
        
    }
}
