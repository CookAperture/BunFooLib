using System.ComponentModel.DataAnnotations;

namespace Foos.Api.Database.Contracts.Entities
{
    public class FooCategoryEntity
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
