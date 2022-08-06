using AutoMapper;
using BunFooLib.Api.Shared.Repository.Contracts;
using Foos.Api.Database.Contracts.Entities;
using Foos.Api.Operation.Contracts;

namespace Foos.Api.Operations.Services
{
    public class FooCategoryService : CrudService<FooCategoryEntity>, IFooCategoryService
    {
        public FooCategoryService(IRepository<FooCategoryEntity> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
