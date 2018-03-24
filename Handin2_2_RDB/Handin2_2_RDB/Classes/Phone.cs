using System.ComponentModel.DataAnnotations;

namespace Handin2_2_RDB.Classes
{
    public class Phone
    {
        [Key]
        //private int _number;
        //private string _info;

        public int Number { get; set; }
        public string Info { get; set; }
    }
}