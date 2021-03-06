﻿using System.ComponentModel.DataAnnotations;

namespace DiplomaBack.DAL.Entities.Restaurant
{
    public class RestaurantCategoryModel
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(24)]
        public string Name { get; set; }
    }
}
