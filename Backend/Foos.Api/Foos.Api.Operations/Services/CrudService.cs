using AutoMapper;
using BunFooLib.Api.Shared.Dto;
using BunFooLib.Api.Shared.Repository.Contracts;
using Foos.Api.Operation.Contracts;

namespace Foos.Api.Operations.Services
{
    public class CrudService<TEntity> : ICrudService<TEntity>
        where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;
        
        public CrudService(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public virtual async Task<TDto> CreateAsync<TDto, TAddDto>(TAddDto addDto)
            where TDto : BaseDto
            where TAddDto : BaseDto
        {
            var entity = _mapper.Map<TEntity>(addDto);
            await _repository.Create(entity);
            return _mapper.Map<TDto>(entity);
        }
        
        public virtual async Task<TDto> ReadAsync<TDto>(int id) where TDto : BaseDto
        {
            var entity = await _repository.ReadById(id);
            return _mapper.Map<TDto>(entity);
        }
        public virtual async Task<IEnumerable<TDto>> ReadAllAsync<TDto>() where TDto : BaseDto
        {
            var entities = await _repository.Read();
            return _mapper.Map<IEnumerable<TDto>>(entities);
        }

        public virtual async Task UpdateAsync<TAddDto>(int id, TAddDto addDto)
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
        
        public virtual async Task DeleteAsync(int id)
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
