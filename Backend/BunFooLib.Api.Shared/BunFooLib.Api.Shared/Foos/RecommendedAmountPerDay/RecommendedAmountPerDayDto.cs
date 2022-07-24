using BunFooLib.Api.Shared.Dto.Foos.Measurement;
using System.ComponentModel.DataAnnotations;

namespace BunFooLib.Api.Shared.Dto.Foos.RecommendedAmountPerDay
{
    public class RecommendedAmountPerDayDto : BaseDto
    {
        [Required]
        public string Amount { get; set; }
        [Required]
        public MeasurementDto Measurement { get; set; }
    }
}
