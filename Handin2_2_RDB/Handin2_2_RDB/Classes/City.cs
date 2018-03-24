using System.ComponentModel.DataAnnotations;

namespace Handin2_2_RDB.Classes
{
    public class City
    {
        [Key]
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }
        public int ZipCode { get; set; }
        public string CityName { get; set; }

    }
}