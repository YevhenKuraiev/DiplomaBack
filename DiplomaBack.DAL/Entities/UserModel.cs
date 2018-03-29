using Microsoft.AspNetCore.Identity;

namespace DiplomaBack.DAL.Entities
{
    public class UserModel : IdentityUser
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
