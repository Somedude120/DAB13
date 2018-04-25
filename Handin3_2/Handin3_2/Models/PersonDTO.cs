namespace Handin3_2.Models
{
    public class PersonDTO
    {
        public int PersonId { get; set; }

        public string Name { get; set; }

        public string MiddleName { get; set; }

        public string SurName { get; set; }

        public string Email { get; set; }

        public int? AddressList_AddressId { get; set; }

        public virtual Address Address { get; set; }
    }
}