using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace DiplomaBack.DAL.Entities
{
    public class UserModel : IdentityUser
    {
        [MaxLength(25)]
        public string FirstName { get; set; }
        [MaxLength(25)]
        public string LastName { get; set; }
    }
}
