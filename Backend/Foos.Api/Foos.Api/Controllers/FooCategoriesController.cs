using AutoMapper;
using Foos.Api.Database.Contracts;
using Foos.Api.Database.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        public async Task<ActionResult<IEnumerable<FooCategoryEntity>>> GetFooCategories()
        {
            var hotelEntities = await _fooCategoryRepository.Read();
            return Ok(_mapper.Map<IEnumerable<FooCategoryEntity>>(hotelEntities));
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<FooCategoryEntity>> GetFooCategory(int id)
        {
            var hotelEntity = await _fooCategoryRepository.ReadById(id);

            if (hotelEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<FooCategoryEntity>(hotelEntity));
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFooCategory(int id, FooCategoryEntity updateHotelDto)
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
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FooCategoryEntity>> PostFooCategory(FooCategoryEntity hotelDto)
        {
            var hotelEntity = _mapper.Map<FooCategoryEntity>(hotelDto);
            await _fooCategoryRepository.Create(hotelEntity);

            return CreatedAtAction("GetFooCategory", new
            {
                id = hotelEntity.ID,
            }, hotelEntity);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelEntity(int id)
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
