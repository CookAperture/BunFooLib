using AutoMapper;
using BunFooLib.Api.Shared.Dto.Foos.Measurement;
using Foos.Api.Database.Contracts;
using Foos.Api.Database.Contracts.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Foos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementsController : ControllerBase
    {
        private readonly IMeasurementRepository _measurementRepository;
        private readonly IMapper _mapper;

        public MeasurementsController(IMapper mapper, IMeasurementRepository measurementRepository)
        {
            _measurementRepository = measurementRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(MeasurementDto[]), 200)]
        public async Task<ActionResult<IEnumerable<MeasurementDto>>> GetMeasurements()
        {
            var measurementEntities = await _measurementRepository.Read();
            return Ok(_mapper.Map<IEnumerable<MeasurementDto>>(measurementEntities));
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(MeasurementDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MeasurementDto>> GetMeasurement(int id)
        {
            var measurementEntity = await _measurementRepository.ReadById(id);

            if (measurementEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<MeasurementDto>(measurementEntity));
        }

        // PUT: api/Hotels/5
        // To protect from over posting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutMeasurement(int id, MeasurementAddDto updateHotelDto)
        {
            var measurementEntity = await _measurementRepository.ReadById(id);

            if (measurementEntity == null)
            {
                return NotFound();
            }

            if (id != measurementEntity.ID)
            {
                return BadRequest();
            }

            _mapper.Map(updateHotelDto, measurementEntity);

            try
            {
                await _measurementRepository.Update(measurementEntity);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await MeasurementEntityExists(id))
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
        public async Task<ActionResult<MeasurementDto>> PostMeasurement(MeasurementAddDto hotelDto)
        {
            var measurementEntity = _mapper.Map<MeasurementEntity>(hotelDto);
            await _measurementRepository.Create(measurementEntity);

            return CreatedAtAction("GetMeasurement", new
            {
                id = measurementEntity.ID,
            }, measurementEntity);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteMeasurement(int id)
        {
            var hotelEntity = await _measurementRepository.ReadById(id);

            if (hotelEntity == null)
            {
                return NotFound();
            }

            await _measurementRepository.Delete(hotelEntity);

            return NoContent();
        }

        private async Task<bool> MeasurementEntityExists(int id)
        {
            return await _measurementRepository.ReadById(id) != null;
        }
    }
}
