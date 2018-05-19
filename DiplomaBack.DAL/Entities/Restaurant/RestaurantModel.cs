using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiplomaBack.DAL.Entities.Restaurant
{
    public class RestaurantModel
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(25)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Address { get; set; }
        public double MinimunSum { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
        public string Image { get; set; }

        [ForeignKey("CityModel")]
        public int CityId { get; set; }
        public CityModel CityModel { get; set; }

        [ForeignKey("RestaurantCategoryModel")]
        public int CategoryId { get; set; }
        public RestaurantCategoryModel RestaurantCategoryModel { get; set; }
    }
}
