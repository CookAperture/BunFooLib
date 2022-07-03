using BunFooLib.Api.Shared.Dto.Foos.Measurement;
using System.ComponentModel.DataAnnotations;

namespace BunFooLib.Api.Shared.Dto.Foos.RecommendedAmountPerDay
{
    public class RecommendedAmountPerDayDto
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Amount { get; set; }
        [Required]
        public MeasurementDto Measurement { get; set; }
    }
}
