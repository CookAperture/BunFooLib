using BunFooLib.Api.Shared.Repository;
using Foos.Api.Database.Context;
using Foos.Api.Database.Contracts;
using Foos.Api.Database.Contracts.Entities;

namespace Foos.Api.Database.Repositories
{
    public class FooRepository : Repository<FooEntity, FoosDbContext>, IFooRepository
    {
        public FooRepository(FoosDbContext context) : base(context)
        {
        }
    }
}
