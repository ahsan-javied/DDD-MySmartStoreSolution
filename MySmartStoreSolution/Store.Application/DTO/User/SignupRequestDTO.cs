using System.ComponentModel.DataAnnotations;

namespace Store.Application.DTO.User
{
    public class SignupRequestDTO
    {
        [Required]
        [EmailAddress]
        [StringLength(maximumLength: 50, MinimumLength = 5)]
        public string Email { get; set; }
        
        [StringLength(maximumLength: 15)]
        public string Phone { get; set; }

        [Required]
        [StringLength(maximumLength: 150, MinimumLength = 5)]
        public string Password { get; set; }
        
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string FirstName { get; set; }
        
        [StringLength(maximumLength: 50)]
        public string LastName { get; set; }
    }
}
