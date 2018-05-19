using System;
using System.ComponentModel.DataAnnotations;

namespace DiplomaBack.DAL.Entities.Order
{
    public class OrderModel
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(15)]
        public string PhoneNumber { get; set; }
        public double OrderPrice { get; set; }
        public DateTime DateTime { get; set; }

        [MaxLength(250)]
        public string DeliveryAddress { get; set; }
    }
}
