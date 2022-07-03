using System.ComponentModel.DataAnnotations;

namespace Foos.Api.Database.Contracts.Entities
{
    public class RecommendedAmountPerDayEntity
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Amount { get; set; }
        [Required]
        public MeasurementEntity Measurement { get; set; }
    }
}
