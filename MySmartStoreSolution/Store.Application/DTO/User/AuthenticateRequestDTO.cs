using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Store.Application.DTO.User
{
    public class AuthenticateRequestDTO
    {
        [Required]
        [EmailAddress]
        [StringLength(maximumLength: 250, MinimumLength = 5)]
        public string Email { get; set; }
        public string Phone { get; set; }

        [Required]
        [StringLength(maximumLength: 150, MinimumLength = 5)]
        public string Password { get; set; }
    }
}
