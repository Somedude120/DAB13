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
        public class ContactsController : ApiController
        {
            public async Task<IEnumerable<ContactsDTO>> GetContact()
            {
                return await DocumentDBRepository<ContactsDTO>.Get(p => true);
            }

            [ResponseType(typeof(Contacts))]
            public async Task<IHttpActionResult> GetContact(string id)
            {
                var contact = await DocumentDBRepository<Contacts>.Get(p => p.Id == id);

                if (!contact.Any())
                    return NotFound();

                return Ok(contact);
            }

            [ResponseType(typeof(Contacts))]
            public async Task<IHttpActionResult> PutContact(Contacts contact)
            {
                return await DocumentDBRepository<Contacts>.Put(contact);
            }

            [ResponseType(typeof(Contacts))]
            public async Task<IHttpActionResult> PostContact(Contacts contact)
            {
                return await DocumentDBRepository<Contacts>.Post(contact);
            }

            public async Task<IHttpActionResult> DeleteContact(string id)
            {
                return await DocumentDBRepository<Contacts>.Delete(id);
            }




        }
    }