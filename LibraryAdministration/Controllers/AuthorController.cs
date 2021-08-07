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
            /* try
            *  {
            *     context.Authors.Add(author);
            *     context.SaveChanges();
            *     return Ok($"{author.Name}");
            *  }
            *  catch (Exception ex)
            *  {
            *     return BadRequest();
            *  }
            */

            List<Author> authors = GenerateAuthorsList(5);
            authors.Add(author);
            return Ok($"El usuario insertado es {authors.Find(authors => authors.Id == author.Id).Name}");

        }

        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public IActionResult Put(uint id, [FromBody] Author author)
        {
            if (author.Id == id)
            {
                context.Entry(author).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(uint id)
        {
            var author = context.Authors.FirstOrDefault(_author => _author.Id == id);
            if (author != null)
            {
                context.Authors.Remove(author);
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        #endregion
    }
}
