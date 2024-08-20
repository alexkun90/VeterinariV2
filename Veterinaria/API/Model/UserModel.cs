using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class UserModel
    {
        public string? Id { get; set; }
        public string? Username { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public string? Password { get; set; }

        public IList<string>? Roles { get; set; }
    }
}
