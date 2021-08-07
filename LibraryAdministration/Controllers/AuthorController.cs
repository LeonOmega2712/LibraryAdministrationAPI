using LibraryAdministration.Context;
using LibraryAdministration.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryAdministration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        #region AppDbContext initiation for DB usage
        // When a DB is used this code must be used...
        private readonly AppDbContext context;
        public AuthorController(AppDbContext context)
        {
            this.context = context;
        }
        #endregion

        #region Example list creation
        // For showing purposes the next list will be used as an example:
        private static List<Author> GenerateAuthorsList(uint quantity)
        {
            List<Author> Authors = new();
            for (uint i = 1; i <= quantity; i++)
            {
                Author Author = new()
                {
                    Id = i,
                    Name = $"Author {i}",
                    Birthdate = new DateTime(1998, 12, 27),
                    OriginCountry = $"City {i}"
                };
                Authors.Add(Author);
            }

            return Authors;
        }
        #endregion

        #region API Methods
        // GET: api/<AuthorController>
        [HttpGet]
        public IEnumerable<Author> Get()
        {
            /* When a DB is used...
            * return context.Authors.ToList();
            */

            return GenerateAuthorsList(3);
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public Author Get(uint id)
        {
            /* When a DB is used...
            *  var author = context.Authors.FirstOrDefault(_author => _author.Id == id);
            *  return author;
            */
            List<Author> author = GenerateAuthorsList(id + 3);
            Console.WriteLine($"Authors list has {author.Count} elements");
            Console.WriteLine($"Author found by id {id}: {author.Find(author => author.Id == id).Name}");
            return author.Find(author => author.Id == id);
        }

        // POST api/<AuthorController>
        [HttpPost]
        public IActionResult Post([FromBody] Author author)
        {
            context.Authors.Add(author);
            return Ok($"{author.Name}");
        }

        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public IActionResult Put(uint id, [FromBody] Author author)
        {
            try
            {
                if (id != author.Id)
                {
                    return BadRequest();
                }

                var authorToUpdate = context.Authors.FirstOrDefault(author => author.Id == id);

                if (authorToUpdate == null)
                {
                    return NotFound($"Author with id {id} not found");
                }

                authorToUpdate = author;
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return Ok();
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public void Delete(uint id)
        {
        }
        #endregion
    }
}
