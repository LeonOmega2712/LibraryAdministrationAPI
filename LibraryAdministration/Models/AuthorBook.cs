﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAdministration.Models
{
    public class AuthorBook
    {
        [Key]
        public uint Id { get; set; }
        public uint AuthorId { get; set; }
        public uint BookId { get; set; }

        public Author Author { get; set; }
        public Book Book { get; set; }
    }
}
