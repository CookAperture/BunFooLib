using AutoMapper;
using BunFooLib.Api.Shared.Dto.Foos.FooCategory;
using Foos.Api.Database.Contracts;
using Foos.Api.Database.Contracts.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Foos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooCategoriesController : ControllerBase
    {
        private readonly IFooCategoryRepository _fooCategoryRepository;
        private readonly IMapper _mapper;

        public FooCategoriesController(IMapper mapper, IFooCategoryRepository fooCategoryRepository)
        {
            _fooCategoryRepository = fooCategoryRepository;
            _mapper = mapper;
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(FooCategoryDto[]), 200)]
        public async Task<ActionResult<IEnumerable<FooCategoryDto>>> GetFooCategories()
        {
            var hotelEntities = await _fooCategoryRepository.Read();
            return Ok(_mapper.Map<IEnumerable<FooCategoryDto>>(hotelEntities));
        }
        
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(FooCategoryDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FooCategoryDto>> GetFooCategory(int id)
        {
            var hotelEntity = await _fooCategoryRepository.ReadById(id);

            if (hotelEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<FooCategoryDto>(hotelEntity));
        }

        // PUT: api/Hotels/5
        // To protect from over posting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutFooCategory(int id, FooCategoryAddDto updateHotelDto)
        {
            var hotelEntity = await _fooCategoryRepository.ReadById(id);

            if (hotelEntity == null)
            {
                return NotFound();
            }

            if (id != hotelEntity.ID)
            {
                return BadRequest();
            }

            _mapper.Map(updateHotelDto, hotelEntity);

            try
            {
                await _fooCategoryRepository.Update(hotelEntity);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await FooCategoryEntityExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // POST: api/Hotels
        // To protect from over posting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<FooCategoryDto>> PostFooCategory(FooCategoryAddDto hotelDto)
        {
            var hotelEntity = _mapper.Map<FooCategoryEntity>(hotelDto);
            await _fooCategoryRepository.Create(hotelEntity);

            return CreatedAtAction("GetFooCategory", new
            {
                id = hotelEntity.ID,
            }, hotelEntity);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteFooCategoryEntity(int id)
        {
            var hotelEntity = await _fooCategoryRepository.ReadById(id);

            if (hotelEntity == null)
            {
                return NotFound();
            }

            await _fooCategoryRepository.Delete(hotelEntity);

            return NoContent();
        }

        private async Task<bool> FooCategoryEntityExists(int id)
        {
            return await _fooCategoryRepository.ReadById(id) != null;
        }
    }
}
