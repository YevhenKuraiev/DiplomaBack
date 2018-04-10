using System.ComponentModel.DataAnnotations;

namespace DiplomaBack.Models
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        [Compare("Password")]
        public string PasswordConfirm { get; set; }
    }
}
