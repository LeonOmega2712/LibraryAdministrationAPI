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
    public class BookController : ControllerBase
    {
        public List<Book> books = new List<Book>() { 
            new Book()
            { 
                Id = 1,
                Title = "First book",
                YearPublished = new DateTime(2021, 8, 9),
                PageQuantity = 200,
                StockQuantity = 10,
                IdAuthor = 1
            },
            new Book() 
            {
                Id = 2,
                Title = "Second book",
                YearPublished = new DateTime(2020, 7, 8),
                PageQuantity = 100,
                StockQuantity = 15,
                IdAuthor = 1
            },
            new Book()
            {
                Id = 3,
                Title = "Third book",
                YearPublished = new DateTime(2019, 6, 10),
                PageQuantity = 50,
                StockQuantity = 5,
                IdAuthor = 2
            },
            new Book()
            {
                Id = 4,
                Title = "Fourth book",
                YearPublished = new DateTime(2015, 2, 14),
                PageQuantity = 250,
                StockQuantity = 0,
                IdAuthor = 2
            },
            new Book()
            {
                Id = 5,
                Title = "Fifth book",
                YearPublished = new DateTime(2011, 4, 18),
                PageQuantity = 500,
                StockQuantity = 10,
                IdAuthor = 3
            }
        };

        #region API methods
        // GET: api/<BookController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return books;
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public Book Get(uint id)
        {
            return books.FirstOrDefault(books => books.Id == id);
        }

        // POST api/<BookController>
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            books.Add(book);
            return Ok($"The book {books.LastOrDefault().Title} is now in the books list");
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public IActionResult Put(uint id, [FromBody] Book book)
        {
            books.FirstOrDefault(books => books.Id == id).Title = book.Title;
            books.FirstOrDefault(books => books.Id == id).YearPublished = book.YearPublished;
            books.FirstOrDefault(books => books.Id == id).PageQuantity = book.PageQuantity;
            books.FirstOrDefault(books => books.Id == id).StockQuantity = book.StockQuantity;
            books.FirstOrDefault(books => books.Id == id).IdAuthor = book.IdAuthor;

            return Ok($"Book updated: {books.FirstOrDefault(books => books.Id == id).Title}");
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(uint id)
        {
            var booksTitleDeleted = books.FirstOrDefault(books => books.Id == id).Title;
            books.RemoveAt(books.IndexOf(books.FirstOrDefault(books => books.Id == id)));
            return Ok($"Book {booksTitleDeleted} is now deleted");
        }
        #endregion
    }
}
