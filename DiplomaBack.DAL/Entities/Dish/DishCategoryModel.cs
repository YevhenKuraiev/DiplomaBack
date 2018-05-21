using System.ComponentModel.DataAnnotations;

namespace DiplomaBack.DAL.Entities.Dish
{
    public class DishCategoryModel
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(24)]
        public string Name { get; set; }
    }
}
