using AutoMapper;
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
        public IActionResult GetAuthorAndItsBooks(Book RecievedBook)
        {
            Author author = _mapper.Map<Book, Author>(RecievedBook);
            return Ok(author);
        }
    }
}
