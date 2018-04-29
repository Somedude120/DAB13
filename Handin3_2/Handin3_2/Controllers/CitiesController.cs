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

//Done

namespace Handin3_2.Controllers
{
    public class CitiesController : ApiController
    {
        private PersonIndexContext db = new PersonIndexContext();

        // GET: api/Cities
        public IEnumerable<CityDTO> GetCities()
        {

            var city = from b in db.Cities
                select new CityDTO()
                {
                    CityId = b.CityId,
                    CityName = b.CityName,
                    StreetName = b.StreetName,
                    HouseNumber = b.HouseNumber,
                    ZipCode = b.ZipCode,
                };

            return city;
        }

        // GET: api/City/5
        [ResponseType(typeof(CityDTO))]
        public async Task<IHttpActionResult> GetCity(int id)
        {
            var city = await db.Cities.FindAsync(id);
            var cities = await db.Cities.Include(b => b.CityId).Select(b =>
                new CityDTO()
                {
                    CityId = b.CityId,
                    CityName = b.CityName,
                    StreetName = b.StreetName,
                    HouseNumber = b.HouseNumber,
                    ZipCode = b.ZipCode,
                    
                }).SingleOrDefaultAsync(b => b.CityId == id);
            if (cities == null)
                if (city == null)
                {
                    return NotFound();
                }

            return Ok(cities);
        }

        // PUT: api/Cities/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCity(int id, City city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != city.CityId)
            {
                return BadRequest();
            }

            db.Entry(city).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(id))
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

        // POST: api/Cities
        [ResponseType(typeof(City))]
        public async Task<IHttpActionResult> PostCity(City city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cities.Add(city);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = city.CityId }, city);
        }

        // DELETE: api/Cities/5
        [ResponseType(typeof(City))]
        public async Task<IHttpActionResult> DeleteCity(int id)
        {
            City city = await db.Cities.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }

            db.Cities.Remove(city);
            await db.SaveChangesAsync();

            return Ok(city);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CityExists(int id)
        {
            return db.Cities.Count(e => e.CityId == id) > 0;
        }
    }
}