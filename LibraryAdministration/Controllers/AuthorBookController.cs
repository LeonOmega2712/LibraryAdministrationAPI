using AutoMapper;
using LibraryAdministration.DTOs;
using LibraryAdministration.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAdministration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorBookController : ControllerBase
    {
        private readonly IMapper _mapper;

        public AuthorBookController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult GetAuthorAndItsBooks(BookDTO RecievedBook)
        {
            return Ok(_mapper.Map<BookDTO, AuthorDTO>(RecievedBook));
        }

        [HttpGet]
        public IActionResult GetAllAuthorsAndBooks()
        {
            List<AuthorBookDTO> authorBooks = new();
            uint i = 1;
            foreach (var author in authors)
            {
                List<BookDTO> booksOfAuthor = new();
                foreach (var book in books)
                {
                    if (author.Id == book.IdAuthor)
                    {
                        booksOfAuthor.Add(book);
                    }
                }

                authorBooks.Add(new AuthorBookDTO() {
                    Id = i,
                    Author = _mapper.Map<AuthorDTO, Author>(author),
                    Book = _mapper.Map<List<BookDTO>, List<Book>>(booksOfAuthor)
                });
                i++;
            }

            // TODO: Sort by author.name


            return Ok(authorBooks);
        }

        #region Book static list
        public List<BookDTO> books = new List<BookDTO>() {
            new BookDTO()
            {
                Id = 1,
                Title = "First book",
                YearPublished = new DateTime(2021, 8, 9),
                PageQuantity = 200,
                StockQuantity = 10,
                IdAuthor = 1
            },
            new BookDTO()
            {
                Id = 2,
                Title = "Second book",
                YearPublished = new DateTime(2020, 7, 8),
                PageQuantity = 100,
                StockQuantity = 15,
                IdAuthor = 1
            },
            new BookDTO()
            {
                Id = 3,
                Title = "Third book",
                YearPublished = new DateTime(2019, 6, 10),
                PageQuantity = 50,
                StockQuantity = 5,
                IdAuthor = 2
            },
            new BookDTO()
            {
                Id = 4,
                Title = "Fourth book",
                YearPublished = new DateTime(2015, 2, 14),
                PageQuantity = 250,
                StockQuantity = 0,
                IdAuthor = 2
            },
            new BookDTO()
            {
                Id = 5,
                Title = "Fifth book",
                YearPublished = new DateTime(2011, 4, 18),
                PageQuantity = 500,
                StockQuantity = 10,
                IdAuthor = 3
            }
        };
        #endregion

        #region Authors static list
        public List<AuthorDTO> authors = new List<AuthorDTO>() {
            new AuthorDTO()
            {
                Id = 1,
                Name = "Kevin Gabriel",
                Birthdate = new DateTime(1998, 10, 4),
                OriginCountry = "Mexico"
            },
            new AuthorDTO()
            {
                Id = 2,
                Name = "Nicolas de Jesus",
                Birthdate = new DateTime(1997, 8, 18),
                OriginCountry = "Peru"
            },
            new AuthorDTO()
            {
                Id = 3,
                Name = "Juan de Dios",
                Birthdate = new DateTime(1999, 3, 8),
                OriginCountry = "Puerto Rico"
            }
        };
        #endregion
    }
}
