namespace DiplomaBack.BLL.BusinessModels
{
    public class RouteInfo
    {
        //public string From { get; set; }
        //public string To { get; set; }
        public string FullRoute { get; set; }
        public long Distance { get; set; }

        public string GetDefaultRestaurantAddress()
        {
            return "улица Сумская, 15, Харков";
        }
    }
}
