using System.ComponentModel.DataAnnotations;

namespace Handin2_2_RDB.Classes
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }
        public int ZipCode { get; set; }
        public string CityName { get; set; }
        //En til en med byerne
        public Address Address { get; set; }
        public AltAddress AltAddress { get; set; }
    }
}