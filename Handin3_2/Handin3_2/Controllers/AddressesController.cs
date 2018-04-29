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
    public class AddressesController : ApiController
    {
        private PersonIndexContext db = new PersonIndexContext();

        // GET: api/Addresses
        public IEnumerable<AddressDTO> GetAddresses()
        {

            var address = from b in db.Addresses
                          from c in db.Persons
                select new AddressDTO()
                {
                    AddressId = b.AddressId,
                    CityID = b.City.CityId,
                    CityName = b.City.CityName,
                    CityStreet = b.City.StreetName,
                    CityHouseNr = b.City.HouseNumber,
                    CityZip = b.City.ZipCode,

                    Persons = b.Persons.Select(ct => new SimplePersonDTO()
                    {
                        PersonId = ct.PersonId,
                        FirstName = ct.Name,
                        MiddleName = ct.MiddleName,
                        LastName = ct.SurName,
                        Email = ct.Email,
                        AddressID = ct.AddressList_AddressId,
                        PhoneNumbers = c.Phones.Select(dt => new PhoneDTO()
                        {
                            PhoneId = dt.PhoneId,
                            Info = dt.Info,
                            Number = dt.Number,
                        })
                    })
                };

            return address;
        }

        // GET: api/Addresses/5
        [ResponseType(typeof(AddressDTO))]
        public async Task<IHttpActionResult> GetAddress(int id)
        {
            //Kan ikke få adgang til person listen, så kan kun få null ud af telefonbogen
            var addr = await db.Addresses.FindAsync(id);

            var addresses = await db.Addresses.Include(b => b.AddressId).Select(b =>
                new AddressDTO()
                {
                    AddressId = b.AddressId,
                    CityID = b.City.CityId,
                    CityName = b.City.CityName,
                    CityStreet = b.City.StreetName,
                    CityHouseNr = b.City.HouseNumber,
                    CityZip = b.City.ZipCode,
                    Persons = b.Persons.Select(dt => new SimplePersonDTO()
                    {
                        PersonId = dt.PersonId,
                        FirstName = dt.Name,
                        MiddleName = dt.MiddleName,
                        LastName = dt.SurName,
                        Email = dt.Email,
                        AddressID = dt.AddressList_AddressId,

                    })
                }).SingleOrDefaultAsync(b => b.AddressId == id);
            if (addresses == null)
                if (addr == null)
                {
                    return NotFound();
                }

            return Ok(addresses);
        }

        // PUT: api/Addresses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAddress(int id, Address address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != address.AddressId)
            {
                return BadRequest();
            }

            db.Entry(address).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(id))
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

        // POST: api/Addresses
        [ResponseType(typeof(Address))]
        public async Task<IHttpActionResult> PostAddress(Address address)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Addresses.Add(address);
            db.Entry(address).Reference(x => x.City).Load();
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AddressExists(address.AddressId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = address.AddressId }, address);
        }

        // DELETE: api/Addresses/5
        [ResponseType(typeof(Address))]
        public async Task<IHttpActionResult> DeleteAddress(int id)
        {
            Address address = await db.Addresses.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }

            db.Addresses.Remove(address);
            await db.SaveChangesAsync();

            return Ok(address);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AddressExists(int id)
        {
            return db.Addresses.Count(e => e.AddressId == id) > 0;
        }
    }
}