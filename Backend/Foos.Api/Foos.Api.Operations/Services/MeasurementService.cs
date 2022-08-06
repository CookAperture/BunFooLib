using AutoMapper;
using BunFooLib.Api.Shared.Repository.Contracts;
using Foos.Api.Database.Contracts.Entities;
using Foos.Api.Operation.Contracts;

namespace Foos.Api.Operations.Services
{
    public class MeasurementService : CrudService<MeasurementEntity>, IMeasurementService
    {
        public MeasurementService(IRepository<MeasurementEntity> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
