using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Menu
{
    public class UpdateMenuRequestDto
    {
        [Required]
        [MinLength(2, ErrorMessage = "Name should be atleast 2 characters.")]
        [MaxLength(100, ErrorMessage = "Name should be atleast 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MinLength(2, ErrorMessage = "Description should be atleast 2 characters.")]
        [MaxLength(250, ErrorMessage = "Description should be atleast 250 characters.")]
        public string Description { get; set; } = string.Empty;

        [Range(0.001, 10000)]
        public decimal Price { get; set; }
        public string? Image { get; set; }
        public bool Available { get; set; } = true;
        public bool Discounted { get; set; } = false;

        [Range(0.001, 10)]
        public decimal Discount { get; set; } = 1;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}