using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Product:IEntity
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public String ProductName { get; set; }

        [Required]
        public String? ProductDescripton { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    }
}
