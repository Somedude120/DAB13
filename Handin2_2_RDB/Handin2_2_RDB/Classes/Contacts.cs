using System.ComponentModel.DataAnnotations;

namespace Handin2_2_RDB.Classes
{
    public class Contacts
    {

        //private string _name;
        //private string _middlename;
        //private string _surname;
        [Key]
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
    }
}