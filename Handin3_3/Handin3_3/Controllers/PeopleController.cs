using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using Handin3_3.Models;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;

namespace Handin3_3.Controllers
{
    public class PeopleController : ApiController
    {
        public async Task<IEnumerable<Persons>> GetPeople()
        {
            return await DocumentDBRepository<Persons>.Get(p => true);
        }

        [ResponseType(typeof(PersonDetailDTO))]
        public async Task<IHttpActionResult> GetPerson(string id)
        {
            var person = await DocumentDBRepository<PersonDetailDTO>.Get(p => p.Id == id);

            if (!person.Any())
                return NotFound();

            return Ok(person);
        }

        [ResponseType(typeof(PersonDetailDTO))]
        public async Task<IHttpActionResult> PutPerson(PersonDetailDTO person)
        {
            return await DocumentDBRepository<PersonDetailDTO>.Put(person);
        }

        [ResponseType(typeof(PersonDetailDTO))]
        public async Task<IHttpActionResult> PostPerson(PersonDetailDTO person)
        {
            return await DocumentDBRepository<PersonDetailDTO>.Post(person);
        }

        public async Task<IHttpActionResult> DeletePerson(string id)
        {
            return await DocumentDBRepository<PersonDetailDTO>.Delete(id);
        }



    }
}