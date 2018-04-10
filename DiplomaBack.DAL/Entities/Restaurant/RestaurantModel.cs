namespace DiplomaBack.DAL.Entities
{
    public class RestaurantModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double MinimunSum { get; set; }
        public string Decsription { get; set; }
        public string Image { get; set; }
        public int CityId { get; set; }
    }
}
