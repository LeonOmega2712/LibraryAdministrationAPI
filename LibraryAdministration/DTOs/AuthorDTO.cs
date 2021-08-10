using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAdministration.DTOs
{
    public class AuthorDTO
    {
        [Required(ErrorMessage = "The field Id is required")]
        public uint Id { get; set; }

        [Required(ErrorMessage = "The field Name is required")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field Birthdate is required")]
        public DateTime Birthdate { get; set; }

        [Required(ErrorMessage = "The field OriginCountry is required")]
        public string OriginCountry { get; set; }
    }
}
