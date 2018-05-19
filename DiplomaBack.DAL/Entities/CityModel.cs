using System.ComponentModel.DataAnnotations;

namespace DiplomaBack.DAL.Entities
{
    public class CityModel
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(20)]
        public string Name { get; set; }
    }
}
