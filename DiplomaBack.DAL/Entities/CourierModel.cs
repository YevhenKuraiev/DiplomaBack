using DiplomaBack.DAL.Entities.Restaurant;
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
        public virtual UserModel UserModel { get; set; }

        [ForeignKey("Restaurant")]
        public int RestaurantId { get; set; }
        public virtual RestaurantModel Restaurant { get; set; }
    }
}
