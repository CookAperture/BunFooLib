using System.ComponentModel.DataAnnotations;

namespace BunFooLib.Api.Shared.Dto.Foos.Measurement
{
    public class MeasurementDto : BaseDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
