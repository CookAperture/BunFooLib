using BunFooLib.Api.Shared.Repository;
using Foos.Api.Database.Context;
using Foos.Api.Database.Contracts;
using Foos.Api.Database.Contracts.Entities;

namespace Foos.Api.Database.Repositories
{
    public class FooCategoryRepository : Repository<FooCategoryEntity, FoosDbContext>, IFooCategoryRepository
    {
        public FooCategoryRepository(FoosDbContext context) : base(context)
        {
        }
    }
}
