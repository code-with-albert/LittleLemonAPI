using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class CommentReport
    {
        public int Id { get; set; }

        [Required]
        public User ReporterId { get; set; } = null!;

        [Required]
        public string Statement { get; set; } = string.Empty;

        [Required]
        public string Appeal { get; set; } = string.Empty;

        [Required]
        public int CommentId { get; set; }

        [Required]
        public Comment Comment { get; set; } = null!;

        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column(TypeName = "datetime")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}