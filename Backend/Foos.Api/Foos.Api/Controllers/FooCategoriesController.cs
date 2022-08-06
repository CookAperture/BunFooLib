using BunFooLib.Api.Shared.Dto.Foos.FooCategory;
using Foos.Api.Operation.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Foos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooCategoriesController : ControllerBase
    {
        private readonly IFooCategoryService _crudService;

        public FooCategoriesController(IFooCategoryService crudService)
        {
            _crudService = crudService;
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(FooCategoryDto[]), 200)]
        public async Task<ActionResult<IEnumerable<FooCategoryDto>>> GetFooCategories()
        {
            var fooCategoryDto = await _crudService.ReadAllAsync<FooCategoryDto>();
            return Ok(fooCategoryDto);
        }
        
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(FooCategoryDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FooCategoryDto>> GetFooCategory(int id)
        {
            var fooCategoryDto = await _crudService.ReadAsync<FooCategoryDto>(id);
            return Ok(fooCategoryDto);
        }

        // PUT: api/Hotels/5
        // To protect from over posting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutFooCategory(int id, FooCategoryAddDto updateHotelDto)
        {
            await _crudService.UpdateAsync(id, updateHotelDto);
            return NoContent();
        }

        // POST: api/Hotels
        // To protect from over posting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<FooCategoryDto>> PostFooCategory(FooCategoryAddDto fooCategoryAddDto)
        {
            var addedFooCategory = await _crudService.CreateAsync<FooCategoryDto, FooCategoryAddDto>(fooCategoryAddDto);

            return CreatedAtAction("GetFooCategory", new
            {
                id = addedFooCategory.Id,
            }, addedFooCategory);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteFooCategoryEntity(int id)
        {
            await _crudService.DeleteAsync(id);
            return NoContent();
        }
    }
}
