using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiplomaBack.DAL.Entities.Dish
{
    public class DishModel
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(25)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("RestaurantModel")]
        public int RestaurantId { get; set; }
        public Restaurant.RestaurantModel RestaurantModel { get; set; }

        [ForeignKey("DishCategoryModel")]
        public int CategoryId { get; set; }
        public DishCategoryModel DishCategoryModel { get; set; }
    }
}
