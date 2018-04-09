using DiplomaBack.DAL.Entities.Order;
using System;
using System.Collections.Generic;

namespace DiplomaBack.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public List<DishOrderModel> DishOrderModels { get; set; }
        public double TotalPrice { get; set; }
        public DateTime DateTime { get; set; }
        public string DeliveryAddress { get; set; }
    }
}
