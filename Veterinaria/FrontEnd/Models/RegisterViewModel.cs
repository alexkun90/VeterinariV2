using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string UserName { get; set; }
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
