namespace DiplomaBack.DAL.Entities.Order
{
    public class DishOrderModel
    {
        public int Id { get; set; }
        public virtual DishModel DishModel { get; set; }
        public int Quantity { get; set; }
    }
}
