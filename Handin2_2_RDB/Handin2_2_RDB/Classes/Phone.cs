using System.ComponentModel.DataAnnotations;

namespace Handin2_2_RDB.Classes
{
    public class Phone
    {
        
        [Key]
        public string Number { get; set; }
        public string Info { get; set; }
    }
}