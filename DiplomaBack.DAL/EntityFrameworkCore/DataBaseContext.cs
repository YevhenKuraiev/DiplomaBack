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
        public DbSet<CategoryModel> Categories { get; set; }
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
                        CountReviews = 100,
                        Id = 0
                    },
                    new RestaurantModel
                    {
                        Name = "Мафия",
                        CountReviews = 50,
                        Id = 1
                    },
                    new RestaurantModel
                    {
                        Name = "БИг бен",
                        CountReviews = 25,
                        Id = 2
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
                        Image = File.ReadAllBytes(appEnvironment.WebRootPath + "/Files/losos.jpg"),
                        RestaurantId = 0,
                        CategoryId = 0
                    },
                    new DishModel
                    {
                        Name = "Ролл 2",
                        Price = 200,
                        Description = "тестовое описание тестовое описание тестовое описание описание",
                        Image = File.ReadAllBytes(appEnvironment.WebRootPath + "/Files/losos2.jpg"),
                        RestaurantId = 0,
                        CategoryId = 2
                    },
                    new DishModel
                    {
                        Name = "Ролл 3",
                        Price = 175,
                        Description = "тестовое описание тестовое описание тестовое описание описание",
                        Image = File.ReadAllBytes(appEnvironment.WebRootPath + "/Files/losos3.jpg"),
                        RestaurantId = 1,
                        CategoryId = 3
                    }
                    ,
                    new DishModel
                    {
                        Name = "Ролл 4",
                        Price = 225,
                        Description = "тестовое описание тестовое описание тестовое описание описание",
                        Image = File.ReadAllBytes(appEnvironment.WebRootPath + "/Files/losos4.jpg"),
                        RestaurantId = 1,
                        CategoryId = 4
                    }
                    ,
                    new DishModel
                    {
                        Name = "Ролл 5",
                        Price = 85,
                        Description = "тестовое описание тестовое описание тестовое описание описание",
                        Image = File.ReadAllBytes(appEnvironment.WebRootPath + "/Files/losos5.jpg"),
                        RestaurantId = 2,
                        CategoryId = 1
                    }

                );
                context.SaveChanges();
            }

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new CategoryModel
                    {
                        Name = "Суши",
                        Id = 0
                    },
                    new CategoryModel
                    {
                        Name = "Супы",
                        Id = 1
                    },
                    new CategoryModel
                    {
                        Name = "Напитки",
                        Id = 2
                    }
                    ,
                    new CategoryModel
                    {
                        Name = "Пицца",
                        Id = 3
                    }
                    ,
                    new CategoryModel
                    {
                        Name = "Бургеры",
                        Id = 4
                    }

                );
                context.SaveChanges();
            }
        }
    }

}
