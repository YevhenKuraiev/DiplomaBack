using System.IO;
using System.Linq;
using DiplomaBack.DAL.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace DiplomaBack.DAL.EntityFrameworkCore
{
    public class DataBaseContext : DbContext
    {
        public DbSet<CityModel> Cities { get; set; }
        public DbSet<RestaurantModel> Restaurants { get; set; }
        public DbSet<FileModel> Files { get; set; }
        public DbSet<DishModel> Dishes { get; set; }
        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base((DbContextOptions) options)
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
                        Description = "тестовое описание тестовое описание тестовое описание описание",
                        Image = File.ReadAllBytes(appEnvironment.WebRootPath + "/Files/losos.jpg")
                    },
                    new DishModel
                    {
                        Name = "Ролл 2",
                        Price = 200,
                        Description = "тестовое описание тестовое описание тестовое описание описание",
                        Image = File.ReadAllBytes(appEnvironment.WebRootPath + "/Files/losos2.jpg")
                    },
                    new DishModel
                    {
                        Name = "Ролл 3",
                        Price = 175,
                        Description = "тестовое описание тестовое описание тестовое описание описание",
                        Image = File.ReadAllBytes(appEnvironment.WebRootPath + "/Files/losos3.jpg")
                    }
                    ,
                    new DishModel
                    {
                        Name = "Ролл 4",
                        Price = 225,
                        Description = "тестовое описание тестовое описание тестовое описание описание",
                        Image = File.ReadAllBytes(appEnvironment.WebRootPath + "/Files/losos4.jpg")
                    }
                    ,
                    new DishModel
                    {
                        Name = "Ролл 5",
                        Price = 85,
                        Description = "тестовое описание тестовое описание тестовое описание описание",
                        Image = File.ReadAllBytes(appEnvironment.WebRootPath + "/Files/losos5.jpg")
                    }

                );
                context.SaveChanges();
            }


        }
    }

}
