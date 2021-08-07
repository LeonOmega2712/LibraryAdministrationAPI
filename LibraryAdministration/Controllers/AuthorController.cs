using LibraryAdministration.Context;
using LibraryAdministration.Models;
using Microsoft.AspNetCore.Mvc;
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
        // When a DB is used...
        private readonly AppDbContext context;
        public AuthorController(AppDbContext context)
        {
            this.context = context;
        }
        #endregion

        #region Example list creation
        // For showing purposes the next list will be used as an example:
        private List<Author> GenerateAuthorsList(uint quantity)
        {
            List<Author> Authors = new List<Author>();
            for (uint i = 1; i <= quantity; i++)
            {
                Author Author = new Author()
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


        // GET: api/<AuthorController>
        [HttpGet]
        public IEnumerable<Author> Get()
        {
            /*When a DB is used...
            return context.Authors.ToList();*/

            return GenerateAuthorsList(3);
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AuthorController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AuthorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
