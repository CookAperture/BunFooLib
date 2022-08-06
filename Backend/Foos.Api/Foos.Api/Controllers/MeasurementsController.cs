using BunFooLib.Api.Shared.Dto.Foos.Measurement;
using Foos.Api.Operation.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Foos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementsController : ControllerBase
    {
        private readonly IMeasurementService _crudService;

        public MeasurementsController(IMeasurementService crudService)
        {
            _crudService = crudService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(MeasurementDto[]), 200)]
        public async Task<ActionResult<IEnumerable<MeasurementDto>>> GetMeasurements()
        {
            var measurementEntities = await _crudService.ReadAllAsync<MeasurementDto>();
            return Ok(measurementEntities);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(MeasurementDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MeasurementDto>> GetMeasurement(int id)
        {
            var measurementEntity = await _crudService.ReadAsync<MeasurementDto>(id);
            return Ok(measurementEntity);
        }

        // PUT: api/Hotels/5
        // To protect from over posting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutMeasurement(int id, MeasurementAddDto measurementAddDto)
        {
            await _crudService.UpdateAsync(id, measurementAddDto);
            return NoContent();
        }

        // POST: api/Hotels
        // To protect from over posting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<MeasurementDto>> PostMeasurement(MeasurementAddDto measurementAddDto)
        { 
            var measurementDto = await _crudService.CreateAsync<MeasurementDto, MeasurementAddDto>(measurementAddDto);

            return CreatedAtAction("GetMeasurement", new
            {
                id = measurementDto.Id,
            }, measurementDto);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteMeasurement(int id)
        {
            await _crudService.DeleteAsync(id);
            return NoContent();
        }
    }
}
