using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public int Rating { get; set; } = 5;

        [Required]
        public int CommenterId { get; set; }

        [Required]
        public User User { get; set; } = null!;

        [Required]
        public string Statement { get; set; } = string.Empty;

        public bool Removed { get; set; } = false;

        public List<CommentReport> Report { get; } = new List<CommentReport>();

        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column(TypeName = "datetime")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}