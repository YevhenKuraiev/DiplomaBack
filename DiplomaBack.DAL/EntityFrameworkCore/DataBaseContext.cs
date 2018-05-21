using System.Linq;
using DiplomaBack.DAL.Entities;
using DiplomaBack.DAL.Entities.Dish;
using DiplomaBack.DAL.Entities.Order;
using DiplomaBack.DAL.Entities.Restaurant;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DiplomaBack.DAL.EntityFrameworkCore
{
    public class DataBaseContext : IdentityDbContext<UserModel>
    {
        public DbSet<CityModel> Cities { get; set; }
        public DbSet<RestaurantModel> Restaurants { get; set; }
        public DbSet<RestaurantCategoryModel> RestaurantCategories { get; set; }
        public DbSet<DishModel> Dishes { get; set; }
        public DbSet<DishCategoryModel> DishCategories { get; set; }
        public DbSet<CourierModel> Couriers { get; set; }
        public DbSet<DishOrderModel> DishOrders{ get; set; }
        public DbSet<OrderModel> Orders { get; set; }

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
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();
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

            if (!context.RestaurantCategories.Any())
            {
                context.RestaurantCategories.AddRange(
                    new RestaurantCategoryModel()
                    {
                        Name = "Стандарт",
                    }
                );
                context.SaveChanges();
            }

            if (!context.Restaurants.Any())
            {
                context.Restaurants.AddRange(
                    new RestaurantModel
                    {
                        Name = "Fat Goose Pub",
                        Description = "В Харькове есть место, где можно прочувствовать пабную атмосферу настоящей Англии, наслаждаясь при этом аутентичными интерьерами: «Жирный Гусь» всегда рад гостям, какую бы цель вы не преследовали: попробовать новые сорта пива, излить душу бармену под стаканчик виски или же найти истину в вине.",
                        Address = "ул. Космическая, вулиця Космічна, 21, Харків, Харківська область, 61000",
                        MinimunSum = 100,
                        Image = $"{UrlApi}Files/Restaurants/Kharkov/FatGoosePub.png",
                        CityId = 1,
                        CategoryId = 1
                   
                    },
                    new RestaurantModel
                    {
                        Name = "Мафия",
                        Description = "Демократичные цены и высокое качество блюд — " +
                        "вот чем известна сеть ресторанов «Мафия» в Харькове. " +
                        "Изюминкой итальянской кухни в заведении считается " +
                        "фирменная метровая пицца. Выглядит она эффектно, на вкус — " +
                        "изумительное блюдо на тонком тесте с большим количеством начинки. " +
                        "Метровая пицца весит более одного килограмма, потому она — " +
                        "отличный выбор для большой компании.",
                        Address = "улица Квитки-Основьяненко, 7, Харків, Харківська область, 61000",
                        MinimunSum = 99,
                        Image = $"{UrlApi}Files/Restaurants/Kharkov/Mafia.jpg",
                        CityId = 1,
                        CategoryId = 1
                    },
                    new RestaurantModel
                    {
                        Name = "Биг Бен Паб",
                        Description = "Big Ben Pub - это пивной ресторан, пивной бар, " +
                        "НО в первую очередь Big Ben Pub - это настоящий английский паб в Харькове.",
                        Address = "Пр. Науки, 48 | D.48, Харьков 61103, Украина",
                        MinimunSum = 150,
                        Image = $"{UrlApi}Files/Restaurants/Kharkov/BigBenPub.jpg",
                        CityId = 1,
                        CategoryId = 1
                    },
                    new RestaurantModel
                    {
                        Name = "Тест",
                        Description = "Big Ben Pub - это тест",
                        Address = "Пр. тест",
                        MinimunSum = 150,
                        Image = $"{UrlApi}Files/Restaurants/Kharkov/BigBenPub.jpg",
                        CityId = 1,
                        CategoryId = 1
                    }
                );
                context.SaveChanges();
            }

            if (!context.DishCategories.Any())
            {
                context.DishCategories.AddRange(
                    new DishCategoryModel
                    {
                        Name = "Суши",
                    },
                    new DishCategoryModel
                    {
                        Name = "Супы",
                    },
                    new DishCategoryModel
                    {
                        Name = "Бургеры",
                    },
                    new DishCategoryModel
                    {
                        Name = "Напитки",
                    },
                    new DishCategoryModel
                    {
                        Name = "Пицца",
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
                        RestaurantId = 1,
                        CategoryId = 1
                    },
                    new DishModel
                    {
                        Name = "Ролл 2",
                        Price = 200,
                        Description = "тестовое описание тестовое описание тестовое описание описание",
                        Image = $"{UrlApi}Files/Dishes/Sushi/losos2.jpg",
                        RestaurantId = 1,
                        CategoryId = 1
                    },
                    new DishModel
                    {
                        Name = "Ролл 3",
                        Price = 175,
                        Description = "тестовое описание тестовое описание тестовое описание описание",
                        Image = $"{UrlApi}Files/Dishes/Sushi/losos3.jpg",
                        RestaurantId = 2,
                        CategoryId = 1
                    },
                    new DishModel
                    {
                        Name = "Ролл 4",
                        Price = 225,
                        Description = "тестовое описание тестовое описание тестовое описание описание",
                        Image = $"{UrlApi}Files/Dishes/Sushi/losos4.jpg",
                        RestaurantId = 2,
                        CategoryId = 1
                    },
                    new DishModel
                    {
                        Name = "Ролл 5",
                        Price = 85,
                        Description = "тестовое описание тестовое описание тестовое описание описание",
                        Image = $"{UrlApi}Files/Dishes/Sushi/losos5.jpg",
                        RestaurantId = 3,
                        CategoryId = 1
                    },

                    #endregion

                    #region Супы

                    new DishModel
                    {
                        Name = "Суп 1",
                        Price = 85,
                        Description = "тестовое описание тестовое описание тестовое описание описание",
                        Image = $"{UrlApi}Files/Dishes/Soups/soup.jpg",
                        RestaurantId = 3,
                        CategoryId = 1
                    },
                    new DishModel
                    {
                        Name = "Суп 2",
                        Price = 95,
                        Description = "тестовое описание тестовое описание тестовое описание описание",
                        Image = $"{UrlApi}Files/Dishes/Soups/soup2.jpg",
                        RestaurantId = 3,
                        CategoryId = 2
                    },
                    new DishModel
                    {
                        Name = "Суп 3",
                        Price = 125,
                        Description = "тестовое описание тестовое описание тестовое описание описание",
                        Image = $"{UrlApi}Files/Dishes/Soups/soup3.jpg",
                        RestaurantId = 2,
                        CategoryId = 2
                    },
                    new DishModel
                    {
                        Name = "Суп 4",
                        Price = 155,
                        Description = "тестовое описание тестовое описание тестовое описание описание",
                        Image = $"{UrlApi}Files/Dishes/Soups/soup4.jpg",
                        RestaurantId = 2,
                        CategoryId = 2
                    },
                    new DishModel
                    {
                        Name = "Суп 5",
                        Price = 115,
                        Description = "тестовое описание тестовое описание тестовое описание описание",
                        Image = $"{UrlApi}Files/Dishes/Soups/soup5.jpg",
                        RestaurantId = 2,
                        CategoryId = 2
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

            if (!context.Couriers.Any())
            {
                context.Couriers.Add(
                    new CourierModel
                    {
                        UserModel = new UserModel
                        {
                            FirstName = "Courier",
                            LastName = "Courier",
                        },
                         RestaurantId = 0,
                    });
                context.SaveChanges();
            }
        }
    }

}
