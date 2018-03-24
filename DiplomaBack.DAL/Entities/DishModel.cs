namespace DiplomaBack.DAL.Entities
{
    public class DishModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public byte[] Image { get; set; }

        public int RestaurantId { get; set; }
        public int CategoryId { get; set; }
    }
}
