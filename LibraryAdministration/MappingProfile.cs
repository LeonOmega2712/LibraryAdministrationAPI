using AutoMapper;
using LibraryAdministration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAdministration
{
    public class MappingProfile :  Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, Author>().ForMember(destination => destination.Id, origin => origin.MapFrom(source => source.IdAuthor));
        }
    }
}
