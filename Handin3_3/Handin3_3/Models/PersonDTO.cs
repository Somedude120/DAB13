using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using Newtonsoft.Json;
using Swashbuckle.Swagger;

//I know, u know, we all know
//I samarbejde med HANS mit em Flammenwerfer

namespace Handin3_3.Models
{
    public class PersonDTO
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public Phones[] Phone { get; set; }


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class PersonSimpleDTO
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
       
    }

    public class PersonDetailDTO
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        
        public Contacts Contact { get; set; }
        //public Phones Phone { get; set; }


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}

