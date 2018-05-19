using System;
using System.Collections.Generic;
using DiplomaBack.DAL.Entities.Dish;
using DiplomaBack.DAL.Entities.Order;

namespace DiplomaBack.Models
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
