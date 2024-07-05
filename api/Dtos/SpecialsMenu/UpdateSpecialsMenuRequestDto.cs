using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.SpecialsMenu
{
    public class UpdateSpecialsMenuRequestDto
    {
        [Range(typeof(int), "1", "1000")]
        public required int MenuId { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}