using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.User
{
    public class authUserDto
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Token { get; set; } = string.Empty;
    }
}