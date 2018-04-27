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

//I work hard every fucking day!

namespace Handin3_2.Controllers
{

    //Shit so crazy, husk at sætte den her ind i webconfig
    //<add name="PersonIndexContext" connectionString="data source=10.29.0.29;initial catalog=F184DABH2Gr13;persist security info=True;user id=F184DABH2Gr13;password=F184DABH2Gr13;MultipleActiveResultSets=True;App=EntityFramework" providerName="System.Data.SqlClient" />
    public class ContactsController : ApiController
    {
        private PersonIndexContext db = new PersonIndexContext();

        //// GET: api/Contacts
        //public IQueryable<ContactDTO> GetContacts()
        //{
        //    return db.Contacts;
        //}

        //// GET: api/Contacts/5
        //[ResponseType(typeof(Contact))]
        //public async Task<IHttpActionResult> GetContact(int id)
        //{
        //    Contact contact = await db.Contacts.FindAsync(id);
        //    if (contact == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(contact);
        //}
        public IEnumerable<ContactDTO> GetContacts()
        {
            var contact = from b in db.Contacts
                select new ContactDTO()
                {
                    ContactsId = b.ContactsId,
                    Type = b.Type,
 
                    City = b.Address.City.CityName,
                    Street = b.Address.City.StreetName,
                    Housenumber = b.Address.City.HouseNumber,
                    Zip = b.Address.City.ZipCode,

                    Persons = b.Persons.Select(ct => new PersonDTO()
                    {
                        FirstName = ct.Name,
                        MiddleName = ct.MiddleName,
                        LastName = ct.SurName,
                    })
                };
      
            return contact;
        }

        // PUT: api/Contacts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutContact(int id, Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contact.ContactsId)
            {
                return BadRequest();
            }

            db.Entry(contact).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(id))
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

        // POST: api/Contacts
        [ResponseType(typeof(Contact))]
        public async Task<IHttpActionResult> PostContact(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Contacts.Add(contact);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = contact.ContactsId }, contact);
        }

        // DELETE: api/Contacts/5
        [ResponseType(typeof(Contact))]
        public async Task<IHttpActionResult> DeleteContact(int id)
        {
            Contact contact = await db.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            db.Contacts.Remove(contact);
            await db.SaveChangesAsync();

            return Ok(contact);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContactExists(int id)
        {
            return db.Contacts.Count(e => e.ContactsId == id) > 0;
        }
    }
}