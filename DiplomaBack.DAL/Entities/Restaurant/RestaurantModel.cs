using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiplomaBack.DAL.Entities.Restaurant
{
    public class RestaurantModel
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(24)]
        public string Name { get; set; }

        [MaxLength(254)]
        public string Address { get; set; }

        public double MinimunSum { get; set; }

        [MaxLength(510)]
        public string Description { get; set; }

        [MaxLength(510)]
        public string Image { get; set; }

        [ForeignKey("CityModel")]
        public int CityId { get; set; }
        public virtual CityModel CityModel { get; set; }

        [ForeignKey("RestaurantCategoryModel")]
        public int CategoryId { get; set; }
        public virtual RestaurantCategoryModel RestaurantCategoryModel { get; set; }
    }
}
