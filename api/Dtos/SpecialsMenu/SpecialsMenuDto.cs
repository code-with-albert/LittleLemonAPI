using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Menu;

namespace api.Dtos.SpecialsMenu
{
    public class SpecialsMenuDto
    {
        public int Id { get; set; }

        public required int MenuId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public SubMenuDto? Menu { get; set; }
    }
    public class SubSpecialsMenuDto
    {
        public int Id { get; set; }

        public required int MenuId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}