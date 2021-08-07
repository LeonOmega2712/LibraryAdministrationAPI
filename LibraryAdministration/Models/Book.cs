using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAdministration.Models
{
    public class Book
    {
        #region Constructors
        public Book()
        {
        }

        public Book(uint id, string title, DateTime yearPublished, uint pageQuantity, uint stockQuantity, uint idAuthor)
        {
            Id = id;
            Title = title;
            YearPublished = yearPublished;
            PageQuantity = pageQuantity;
            StockQuantity = stockQuantity;
            IdAuthor = idAuthor;
        }
        #endregion

        #region Properties
        [Key]
        public uint Id { get; set; }
        public string Title { get; set; }
        public DateTime YearPublished { get; set; }
        public uint PageQuantity { get; set; }
        public uint StockQuantity { get; set; }
        public uint IdAuthor { get; set; } 
        #endregion
    }
}
