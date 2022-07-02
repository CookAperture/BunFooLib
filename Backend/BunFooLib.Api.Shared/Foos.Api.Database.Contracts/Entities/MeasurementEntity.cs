using System.ComponentModel.DataAnnotations;

namespace Foos.Api.Database.Contracts.Entities
{
    public class MeasurementEntity
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
