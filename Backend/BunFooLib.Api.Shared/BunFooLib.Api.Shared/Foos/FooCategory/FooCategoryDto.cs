using System.ComponentModel.DataAnnotations;

namespace BunFooLib.Api.Shared.Dto.Foos.FooCategory
{
    public class FooCategoryDto : BaseDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
