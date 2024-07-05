using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace api.Models
{
    public class SpecialsMenu
    {
        public int Id { get; set; }

        public required int MenuId { get; set; }

        public Menu? Menu { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}