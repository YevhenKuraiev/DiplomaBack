namespace DiplomaBack.DAL.Entities
{
    public class RestaurantModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string MinimunSum { get; set; }
        public string Decsription { get; set; }
        public int CountReviews { get; set; }

        public int CityId { get; set; }
    }
}
