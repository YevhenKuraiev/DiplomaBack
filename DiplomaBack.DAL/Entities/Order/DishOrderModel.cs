namespace DiplomaBack.DAL.Entities.Order
{
    public class DishOrderModel
    {
        public int Id { get; set; }
        public int DishId { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
    }
}
