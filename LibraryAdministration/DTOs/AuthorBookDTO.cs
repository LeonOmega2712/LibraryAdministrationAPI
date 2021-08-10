using LibraryAdministration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace LibraryAdministration.DTOs
{
    [DataContract]
    public class AuthorBookDTO
    {
        [DataMember]
        public uint Id { get; set; }

        [DataMember]
        public Author Author { get; set; }

        [DataMember]
        public List<Book> Book { get; set; }
    }
}
