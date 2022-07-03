using System.ComponentModel.DataAnnotations;

namespace BunFooLib.Api.Shared.Dto.Foos.RecommendedAmountPerDay
{
    public class RecommendedAmountPerDayAddDto
    {
        [Required]
        public string Amount { get; set; }
        [Required]
        public int MeasurementId { get; set; }
    }
}
