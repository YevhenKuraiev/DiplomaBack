using Microsoft.AspNetCore.Identity;

namespace DiplomaBack.DAL.Entities
{
    public class UserModel : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
