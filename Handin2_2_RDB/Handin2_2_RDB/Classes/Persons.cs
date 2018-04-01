using System.ComponentModel.DataAnnotations;

namespace Handin2_2_RDB.Classes
{
    public class Persons
    {
        [Key]
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
    }
}