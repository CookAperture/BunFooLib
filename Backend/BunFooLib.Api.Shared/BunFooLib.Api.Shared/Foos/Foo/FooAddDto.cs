using BunFooLib.Api.Shared.Dto.Foos.FooCategory;
using BunFooLib.Api.Shared.Dto.Foos.RecommendedAmountPerDay;
using System.ComponentModel.DataAnnotations;

namespace BunFooLib.Api.Shared.Dto.Foos.Foo
{
    public class FooAddDto
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int RecommendedAmountPerDayId { get; set; }
    }
}
