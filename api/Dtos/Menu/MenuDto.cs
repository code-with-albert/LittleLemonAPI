using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.SpecialsMenu;

namespace api.Dtos.Menu
{
    public class MenuDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public string? Image { get; set; }
        public bool Available { get; set; } = true;
        public bool Discounted { get; set; } = false;
        public decimal Discount { get; set; } = 1;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public SubSpecialsMenuDto? Special { get; set; }
    }
    public class SubMenuDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public string? Image { get; set; }
        public bool Available { get; set; } = true;
        public bool Discounted { get; set; } = false;
        public decimal Discount { get; set; } = 1;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}