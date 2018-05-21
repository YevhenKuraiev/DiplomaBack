using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace DiplomaBack.DAL.Entities
{
    public class UserModel : IdentityUser
    {
        [MaxLength(24)]
        public string FirstName { get; set; }

        [MaxLength(24)]
        public string LastName { get; set; }
    }
}
