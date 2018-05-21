using DiplomaBack.DAL.Entities.Restaurant;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiplomaBack.DAL.Entities.Dish
{
    public class DishModel
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(24)]
        public string Name { get; set; }

        [MaxLength(510)]
        public string Description { get; set; }
        public double Price { get; set; }

        [MaxLength(510)]
        public string Image { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("RestaurantModel")]
        public int RestaurantId { get; set; }
        public virtual RestaurantModel RestaurantModel { get; set; }

        [ForeignKey("DishCategoryModel")]
        public int CategoryId { get; set; }
        public virtual DishCategoryModel DishCategoryModel { get; set; }
    }
}
