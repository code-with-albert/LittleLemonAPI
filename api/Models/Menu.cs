using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Menu
    {
        public int Id { get; set; }

        public required string Name { get; set; }
        public required string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public string? Image { get; set; }

        public bool Available { get; set; } = true;

        public bool Discounted { get; set; } = false;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Discount { get; set; } = 1;
        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Column(TypeName = "datetime")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public SpecialsMenu? Special { get; set; }
    }
}