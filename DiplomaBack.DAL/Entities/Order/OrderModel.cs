﻿using System;
using System.Collections.Generic;

namespace DiplomaBack.DAL.Entities.Order
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public double OrderPrice { get; set; }
        public DateTime DateTime { get; set; }
        public string DeliveryAddress { get; set; }
    }
}
