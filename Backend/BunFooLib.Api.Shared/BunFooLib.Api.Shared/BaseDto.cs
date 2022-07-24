using System.ComponentModel.DataAnnotations;

namespace BunFooLib.Api.Shared.Dto
{
    public class BaseDto
    {
        [Required]
        public int Id { get; set; }
    }
}
