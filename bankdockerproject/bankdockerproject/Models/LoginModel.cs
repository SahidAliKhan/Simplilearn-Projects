using System.ComponentModel.DataAnnotations;

namespace bankdockerproject.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "UserName is required")]
        public string username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
