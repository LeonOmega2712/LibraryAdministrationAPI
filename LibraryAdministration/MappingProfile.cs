using AutoMapper;
using LibraryAdministration.DTOs;
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
            CreateMap<BookDTO, AuthorDTO>().ForMember(destination => destination.Id, origin => origin.MapFrom(source => source.IdAuthor));
            
            CreateMap<Book, BookDTO>();
            CreateMap<BookDTO, Book>();

            CreateMap<Author, AuthorDTO>();
            CreateMap<AuthorDTO, Author>();

            CreateMap<AuthorBook, AuthorBookDTO>();
            CreateMap<AuthorBookDTO, AuthorBook>();

            CreateMap<List<AuthorBook>, List<AuthorBookDTO>>();
            CreateMap<List<AuthorBookDTO>, List<AuthorBook>>();
        }
    }
}
