using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LibraryAdministration.DTOs
{
    public class BookDTO
    {
        [Required(ErrorMessage = "The field Id is required")]
        public uint Id { get; set; }

        [Required(ErrorMessage = "The field Title is required")]
        [StringLength(100)]
        public string Title { get; set; }

        [Required(ErrorMessage = "The field YearPublished is required")]
        public DateTime YearPublished { get; set; }

        [Required(ErrorMessage = "The field PageQuantity is required")]
        public uint PageQuantity { get; set; }

        [Required(ErrorMessage = "The field StockQuantity is required")]
        public uint StockQuantity { get; set; }

        [Required(ErrorMessage = "The field IdAuthor is required")]
        public uint IdAuthor { get; set; }

        public bool Available
        {
            get { return StockQuantity != 0; }
        }
    }
}
