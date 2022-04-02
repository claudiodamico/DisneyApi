using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisneyApi.Domain.DTOs
{
    public class UserLoginDto
    {
        [StringLength(50, MinimumLength = 8)]
        public string Email { get; set; }

        [StringLength(30, MinimumLength = 8)]
        public string Password { get; set; }
    }
}
