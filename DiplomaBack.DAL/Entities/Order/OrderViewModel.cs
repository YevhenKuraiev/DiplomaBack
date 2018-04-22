using System;
using System.Collections.Generic;
using System.Text;

namespace DiplomaBack.DAL.Entities.Order
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public IEnumerable<DishModel> Dishes { get; set; }
        public double OrderPrice { get; set; }
        public DateTime DateTime { get; set; }
        public string DeliveryAddress { get; set; }
    }
}
