using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DiplomaBack.Models
{
    public class DataBaseContext : DbContext
    {
        public DbSet<CityModel> Cities { get; set; }
        public DbSet<RestaurantModel> Restaurants { get; set; }
        public DbSet<FileModel> Files { get; set; }
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        { }
    }

    public static class SampleData
    {
        public static void Initialize(DataBaseContext context)
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
        }
    }

}
