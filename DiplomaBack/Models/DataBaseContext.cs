using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DiplomaBack.Models
{
    public class DataBaseContext : DbContext
    {
        public DbSet<CityModel> Cities { get; set; }
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
                        Name = "iPhone 6S",
                    },
                    new CityModel
                    {
                        Name = "Samsung Galaxy Edge",
                    },
                    new CityModel
                    {
                        Name = "Lumia 950",
                    }
                );
                context.SaveChanges();
            }
        }
    }

}
