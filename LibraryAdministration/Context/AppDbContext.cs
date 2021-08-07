using LibraryAdministration.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAdministration.Context
{
    public class AppDbContext:DbContext
    {
        #region Constructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        } 
        #endregion

        #region Database entities
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; } 
        #endregion
    }
}
