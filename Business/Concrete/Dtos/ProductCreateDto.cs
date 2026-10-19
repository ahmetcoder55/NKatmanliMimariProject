using System.ComponentModel.DataAnnotations;

namespace Business.Concrete.Dtos
{
    public record ProductCreateDto
    {
        [Required]
        public String ProductName { get; set; }

        [Required]
        public String? ProductDescripton { get; set; }
    }
}