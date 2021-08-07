using LibraryAdministration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAdministration.Repositories
{
    public interface IAuthor
    {
        Task<IEnumerable<Author>> Get();
        Task<Author> Get(int id);
        Task<Author> Create(Author author);
        Task Update(Author author);
        Task Delete(int id);
    }
}
