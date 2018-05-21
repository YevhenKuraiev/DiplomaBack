using DiplomaBack.DAL.Entities.Restaurant;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiplomaBack.DAL.Entities.Order
{
    public class OrderModel
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(24)]
        public string PhoneNumber { get; set; }
        public double OrderPrice { get; set; }
        public DateTime DateTime { get; set; }

        [MaxLength(254)]
        public string DeliveryAddress { get; set; }

        [ForeignKey("Restaurant")]
        public int RestaurantId { get; set; }
        public virtual RestaurantModel Restaurant { get; set; }
    }
}
