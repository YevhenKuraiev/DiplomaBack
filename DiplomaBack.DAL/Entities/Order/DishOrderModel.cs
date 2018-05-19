using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DiplomaBack.DAL.Entities.Dish;

namespace DiplomaBack.DAL.Entities.Order
{
    public class DishOrderModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("DishModel")]
        public int DishId { get; set; }
        public DishModel DishModel { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("OrderModel")]
        public int OrderId { get; set; }
        public OrderModel OrderModel { get; set; }
    }
}
