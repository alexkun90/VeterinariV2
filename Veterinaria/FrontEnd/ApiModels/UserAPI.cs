using System.ComponentModel.DataAnnotations;

namespace FrontEnd.ApiModels
{
    public class UserAPI
    {
        public string? Id { get; set; }
        public string? Username { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public string? Password { get; set; }

        public IList<string>? Roles { get; set; }
    }
}
