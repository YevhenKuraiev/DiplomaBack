using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DiplomaBack.Models
{
    public class DataBaseContext : DbContext
    {
        public DbSet<CityModel> Cities { get; set; }
        public DbSet<RestaurantModel> Restaurants { get; set; }
        public DbSet<FileModel> Files { get; set; }
        public DbSet<DishModel> Dishes { get; set; }
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        { }
    }

    public static class SampleData
    {
        public static void Initialize(DataBaseContext context, IHostingEnvironment appEnvironment)
        {
            if (!context.Cities.Any())
            {
                context.Cities.AddRange(
                    new CityModel
                    {
                        Name = "Харьков",
                    },
                    new CityModel
                    {
                        Name = "Киев",
                    },
                    new CityModel
                    {
                        Name = "Львов",
                    }
                );
                context.SaveChanges();
            }

            if (!context.Restaurants.Any())
            {
                context.Restaurants.AddRange(
                    new RestaurantModel
                    {
                        Name = "Гусь",
                        CountReviews = 100
                    },
                    new RestaurantModel
                    {
                        Name = "Мафия",
                        CountReviews = 50
                    },
                    new RestaurantModel
                    {
                        Name = "БИг бен",
                        CountReviews = 25
                    }
                );
                context.SaveChanges();
            }

            if (!context.Dishes.Any())
            {
                context.Dishes.AddRange(
                    new DishModel
                    {
                        Name = "Ролл",
                        Price = 150,
                        Description = "тестовое описание тестовое описание тестовое описание",
                        Image = File.ReadAllBytes(appEnvironment.WebRootPath + "/Files/losos.jpg")
                    }
            
                );
                context.SaveChanges();
            }


        }
    }

}
