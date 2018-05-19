using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiplomaBack.DAL.Entities
{
    public class CourierModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("UserModel")]
        public string IdentityId { get; set; }
        public UserModel UserModel { get; set; } 
    }
}
