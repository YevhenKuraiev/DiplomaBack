using System.Linq;
using DiplomaBack.DAL.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DiplomaBack.DAL.EntityFrameworkCore
{
    public class DataBaseContext : IdentityDbContext<UserModel>
    {
        public DbSet<CityModel> Cities { get; set; }
        public DbSet<RestaurantModel> Restaurants { get; set; }
        public DbSet<FileModel> Files { get; set; }
        public DbSet<DishModel> Dishes { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public new DbSet<UserModel> Users { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base((DbContextOptions) options)
        {
        }
    }

    public static class SampleData
    {
        private const string UrlApi = "http://localhost:60326/";

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
                    },
                    new RestaurantModel
                    {
                        Name = "Мафия",
                        CountReviews = 50,
                    },
                    new RestaurantModel
                    {
                        Name = "БИг бен",
                        CountReviews = 25,
                    }
                );
                context.SaveChanges();
            }

            if (!context.Dishes.Any())
            {
                context.Dishes.AddRange(

                    #region Роллы

                    new DishModel
                    {
                        Name = "Ролл",
                        Price = 150,
                        Description = "тестовое описание тестовое описание тестовое описание описание",
                        Image = $"{UrlApi}Files/Dishes/Sushi/losos.jpg",
                        RestaurantId = 0,
                        CategoryId = 0
                    },
                    new DishModel
                    {
                        Name = "Ролл 2",
                        Price = 200,
                        Description = "тестовое описание тестовое описание тестовое описание описание",
                        Image = $"{UrlApi}Files/Dishes/Sushi/losos2.jpg",
                        RestaurantId = 0,
                        CategoryId = 0
                    },
                    new DishModel
                    {
                        Name = "Ролл 3",
                        Price = 175,
                        Description = "тестовое описание тестовое описание тестовое описание описание",
                        Image = $"{UrlApi}Files/Dishes/Sushi/losos3.jpg",
                        RestaurantId = 1,
                        CategoryId = 0
                    },
                    new DishModel
                    {
                        Name = "Ролл 4",
                        Price = 225,
                        Description = "тестовое описание тестовое описание тестовое описание описание",
                        Image = $"{UrlApi}Files/Dishes/Sushi/losos4.jpg",
                        RestaurantId = 1,
                        CategoryId = 0
                    },
                    new DishModel
                    {
                        Name = "Ролл 5",
                        Price = 85,
                        Description = "тестовое описание тестовое описание тестовое описание описание",
                        Image = $"{UrlApi}Files/Dishes/Sushi/losos5.jpg",
                        RestaurantId = 2,
                        CategoryId = 0
                    },

                    #endregion

                    #region Супы

                    new DishModel
                    {
                        Name = "Суп 1",
                        Price = 85,
                        Description = "тестовое описание тестовое описание тестовое описание описание",
                        Image = $"{UrlApi}Files/Dishes/Soups/soup.jpg",
                        RestaurantId = 2,
                        CategoryId = 1
                    },
                    new DishModel
                    {
                        Name = "Суп 2",
                        Price = 95,
                        Description = "тестовое описание тестовое описание тестовое описание описание",
                        Image = $"{UrlApi}Files/Dishes/Soups/soup2.jpg",
                        RestaurantId = 2,
                        CategoryId = 1
                    },
                    new DishModel
                    {
                        Name = "Суп 3",
                        Price = 125,
                        Description = "тестовое описание тестовое описание тестовое описание описание",
                        Image = $"{UrlApi}Files/Dishes/Soups/soup3.jpg",
                        RestaurantId = 3,
                        CategoryId = 1
                    },
                    new DishModel
                    {
                        Name = "Суп 4",
                        Price = 155,
                        Description = "тестовое описание тестовое описание тестовое описание описание",
                        Image = $"{UrlApi}Files/Dishes/Soups/soup4.jpg",
                        RestaurantId = 2,
                        CategoryId = 1
                    },
                    new DishModel
                    {
                        Name = "Суп 5",
                        Price = 115,
                        Description = "тестовое описание тестовое описание тестовое описание описание",
                        Image = $"{UrlApi}Files/Dishes/Soups/soup5.jpg",
                        RestaurantId = 2,
                        CategoryId = 1
                    },

                    #endregion

                    #region Бургеры


                    new DishModel
                    {
                        Name = "Бургер 1",
                        Price = 85,
                        Description = "тестовое описание тестовое описание тестовое описание описание",
                        Image = $"{UrlApi}Files/Dishes/Burgers/burger1.jpg",
                        RestaurantId = 1,
                        CategoryId = 2
                    },
                    new DishModel
                    {
                        Name = "Бургер 2",
                        Price = 65,
                        Description = "тестовое описание тестовое описание тестовое описание описание",
                        Image = $"{UrlApi}Files/Dishes/Burgers/burger2.jpg",
                        RestaurantId = 1,
                        CategoryId = 2
                    }

                    #endregion


                );
                context.SaveChanges();
            }

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new CategoryModel
                    {
                        Name = "Суши",
                    },
                    new CategoryModel
                    {
                        Name = "Супы",
                    },
                    new CategoryModel
                    {
                        Name = "Бургеры",
                    },
                    new CategoryModel
                    {
                        Name = "Напитки",
                    },
                    new CategoryModel
                    {
                        Name = "Пицца",
                    }


                );
                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new UserModel
                    {
                        Name = "Admin",
                        Login = "admin",
                        Password = "admin"
                    });
                context.SaveChanges();
            }
        }
    }

}
