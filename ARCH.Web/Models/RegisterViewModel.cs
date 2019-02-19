using System.ComponentModel.DataAnnotations;

namespace ARCH.Web.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
