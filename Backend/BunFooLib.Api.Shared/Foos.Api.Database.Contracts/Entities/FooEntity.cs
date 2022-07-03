using System.ComponentModel.DataAnnotations;

namespace Foos.Api.Database.Contracts.Entities
{
    public class FooEntity
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public FooCategoryEntity Category { get; set; }
        [Required]
        public RecommendedAmountPerDayEntity RecommendedAmountPerDay { get; set; }
    }
}
