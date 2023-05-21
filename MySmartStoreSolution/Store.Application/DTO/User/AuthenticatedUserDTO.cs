
using System.Text.Json.Serialization;

namespace Store.Application.DTO.User
{
    public class AuthenticatedUserDTO
    {
        [JsonIgnore]
        public Int64? Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }
    }
}
