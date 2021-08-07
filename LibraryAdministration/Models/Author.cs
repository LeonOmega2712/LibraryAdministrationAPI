using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAdministration.Models
{
    public class Author
    {
        #region Constructors
        public Author()
        {
        }

        public Author(uint id, string name, DateTime birthdate, string originCountry)
        {
            Id = id;
            Name = name;
            Birthdate = birthdate;
            OriginCountry = originCountry;
        }
        #endregion

        #region Properties
        [Key]
        public uint Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string OriginCountry { get; set; }
        #endregion
    }
}
