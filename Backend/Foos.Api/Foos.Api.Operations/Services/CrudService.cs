using AutoMapper;
using BunFooLib.Api.Shared.Dto;
using BunFooLib.Api.Shared.Repository.Contracts;
using Foos.Api.Operation.Contracts;

namespace Foos.Api.Operations.Services
{
    public class CrudService<TEntity> : ICrudService
        where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;
        
        public CrudService(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<TDto> CreateAsync<TDto, TAddDto>(TAddDto addDto)
            where TDto : BaseDto
            where TAddDto : BaseDto
        {
            var entity = _mapper.Map<TEntity>(addDto);
            await _repository.Create(entity);
            return _mapper.Map<TDto>(entity);
        }
        
        public async Task<TDto> ReadAsync<TDto>(int id) where TDto : BaseDto
        {
            var entity = await _repository.ReadById(id);
            return _mapper.Map<TDto>(entity);
        }
        
        public async Task UpdateAsync<TAddDto>(int id, TAddDto addDto)
            where TAddDto : BaseDto
        {
            var entity = await _repository.ReadById(id);

            if (entity == null)
            {
                throw new KeyNotFoundException("Could not find entity with id " + id);
            }

            _mapper.Map(addDto, entity);
            
            await _repository.Update(entity);
            }
        
        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.ReadById(id);

            if (entity == null)
            {
                throw new KeyNotFoundException("Could not find entity with id " + id);
            }

            await _repository.Delete(entity);
        }
    }
}
