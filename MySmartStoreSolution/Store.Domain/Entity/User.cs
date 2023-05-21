
using System.ComponentModel.DataAnnotations;

namespace Store.Domain.Entity
{
    public class User : Base
    {
        public Int64 Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public byte[] PasswordHash { get; set; } 
        public byte[] PasswordSalt { get; set; }
        public string? Token { get; set; }
    }
}
