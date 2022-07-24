using BunFooLib.Api.Shared.Dto;

namespace Foos.Api.Operation.Contracts
{
    public interface ICrudService
    {
        Task<TDto> CreateAsync<TDto, TAddDto>(TAddDto entity) 
            where TAddDto : BaseDto
            where TDto : BaseDto;
        Task<TDto> ReadAsync<TDto>(int id)
            where TDto : BaseDto;
        Task UpdateAsync<TDto>(int id, TDto entity)
            where TDto : BaseDto;
        Task DeleteAsync(int id);
    }
}
