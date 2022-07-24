using BunFooLib.Api.Shared.Dto.Foos.FooCategory;
using BunFooLib.Api.Shared.Dto.Foos.RecommendedAmountPerDay;
using System.ComponentModel.DataAnnotations;

namespace BunFooLib.Api.Shared.Dto.Foos.Foo
{
    public class FooDto : BaseDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public FooCategoryDto Category { get; set; }
        [Required]
        public RecommendedAmountPerDayDto RecommendedAmountPerDay { get; set; }
    }
}
