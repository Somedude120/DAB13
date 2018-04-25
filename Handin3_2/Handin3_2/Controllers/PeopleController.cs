﻿using System;
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
    public class PeopleController : ApiController
    {
        private PersonIndexContext db = new PersonIndexContext();

        //// GET api/Books
        //public IQueryable<BookDTO> GetBooks()
        //{
        //    var books = from b in db.Books
        //        select new BookDTO()
        //        {
        //            Id = b.Id,
        //            Title = b.Title,
        //            AuthorName = b.Author.Name
        //        };

        //    return books;
        //}


        // GET: api/People
        public IQueryable<PersonDTO> GetPersons()
        {
            var person = from b in db.Persons
                select new PersonDTO()
                {
                    PersonId = b.PersonId,
                    Name = b.Name,
                    Email = b.Email
                };
            return person;
        }

        // GET: api/People/5
        [ResponseType(typeof(PersonDTO))]
        public async Task<IHttpActionResult> GetPerson(int id)
        {
            var person = await db.Persons.FindAsync(id);
            var people = await db.Persons.Include(b => b.Name).Select(b =>
                new PersonDTO()
                {
                    PersonId = b.PersonId,
                    Name = b.Name,
                    MiddleName = b.MiddleName,
                    SurName = b.SurName,
                    Email = b.Email,
                }).SingleOrDefaultAsync(b => b.PersonId == id);
            if (people == null)
                if (person == null)
            {
                return NotFound();
            }

            return Ok(people);
        }

        // PUT: api/People/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPerson(int id, Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != person.PersonId)
            {
                return BadRequest();
            }

            db.Entry(person).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
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

        [ResponseType(typeof(Person))]
        public async Task<IHttpActionResult> PostBook(Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Persons.Add(person);
            await db.SaveChangesAsync();

            // New code:
            // Load author name
            db.Entry(person).Reference(x => x.Name).Load();

            var dto = new PersonDTO()
            {
                PersonId = person.PersonId,
                Name = person.Name,
            };

            return CreatedAtRoute("DefaultApi", new { id = person.PersonId }, dto);
        }

        // POST: api/People
        [ResponseType(typeof(Person))]
        public async Task<IHttpActionResult> PostPerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Persons.Add(person);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = person.PersonId }, person);
        }

        // DELETE: api/People/5
        [ResponseType(typeof(Person))]
        public async Task<IHttpActionResult> DeletePerson(int id)
        {
            Person person = await db.Persons.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            db.Persons.Remove(person);
            await db.SaveChangesAsync();

            return Ok(person);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonExists(int id)
        {
            return db.Persons.Count(e => e.PersonId == id) > 0;
        }
    }
}