using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Handin3_2.Models;

namespace Handin3_2.Controllers
{
    public class PhonesController : ApiController
    {
        private PersonIndexContext db = new PersonIndexContext();

        // GET: api/Addresses
        public IEnumerable<PhoneDTO> GetPhones()
        {

            var phone = from b in db.Phones
                from c in db.Persons
                select new PhoneDTO()
                {
                    PhoneId = b.PhoneId,
                    Number = b.Number,
                    ContactsId = b.Contacts_ContactsId,
                    Info = b.Info,
                    
                    Persons = b.Persons.Select(ct => new SimplePersonIdDTO()
                    {
                        PersonId = ct.PersonId,
                        FirstName = ct.Name,
                        MiddleName = ct.MiddleName,
                        LastName = ct.SurName,
                        Email = ct.Email,
                        AddressID = ct.Addressid,
                        
                    })
                };

            return phone;
        }

        // GET: api/Addresses/5
        [ResponseType(typeof(AddressDTO))]
        public async Task<IHttpActionResult> GetPhone(int id)
        {
            //Kan ikke få adgang til person listen, så kan kun få null ud af telefonbogen
            var addr = await db.Phones.FindAsync(id);

            var addresses = await db.Phones.Include(b => b.PhoneId).Select(b =>
                new PhoneDTO()
                {
                    PhoneId = b.PhoneId,
                    Number = b.Number,
                    ContactsId = b.Contacts_ContactsId,
                    Info = b.Info,

                    Persons = b.Persons.Select(ct => new SimplePersonIdDTO()
                    {
                        PersonId = ct.PersonId,
                        FirstName = ct.Name,
                        MiddleName = ct.MiddleName,
                        LastName = ct.SurName,
                        Email = ct.Email,
                        AddressID = ct.Addressid,

                    })
                }).SingleOrDefaultAsync(b => b.PhoneId == id);
            if (addresses == null)
                if (addr == null)
                {
                    return NotFound();
                }

            return Ok(addresses);
        }

        // PUT: api/Phones/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPhone(int id, Phone phone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != phone.PhoneId)
            {
                return BadRequest();
            }

            db.Entry(phone).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhoneExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Phones
        [ResponseType(typeof(Phone))]
        public async Task<IHttpActionResult> PostPhone(Phone phone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Phones.Add(phone);
            await db.SaveChangesAsync();

            var dto = new PhoneDTO()
            {
                PhoneId = phone.PhoneId,
                Number = phone.Number,
                ContactsId = phone.Contacts_ContactsId,
                Info = phone.Info,

                Persons = phone.Persons.Select(ct => new SimplePersonIdDTO()
                {
                    PersonId = ct.PersonId,
                    FirstName = ct.Name,
                    MiddleName = ct.MiddleName,
                    LastName = ct.SurName,
                    Email = ct.Email,
                    AddressID = ct.Addressid,

                })
            };

            return CreatedAtRoute("DefaultApi", new { id = phone.PhoneId }, dto);
        }

        // DELETE: api/Phones/5
        [ResponseType(typeof(Phone))]
        public async Task<IHttpActionResult> DeletePhone(int id)
        {
            Phone phone = await db.Phones.FindAsync(id);
            if (phone == null)
            {
                return NotFound();
            }

            db.Phones.Remove(phone);
            await db.SaveChangesAsync();

            return Ok(phone);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PhoneExists(int id)
        {
            return db.Phones.Count(e => e.PhoneId == id) > 0;
        }
    }
}