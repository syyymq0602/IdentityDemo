using AutoMapper;
using BooksAppStore.Authors.DTOs;
using BooksAppStore.BooksContracts.DTOs;
using BooksAppStore.DomainAuthors;
using BooksAppStore.DomainBooks;

namespace BooksAppStore
{
    public class BooksAppStoreApplicationAutoMapperProfile : Profile
    {
        public BooksAppStoreApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<Book, BookDto>();
            CreateMap<CreateUpdateBookDto, Book>();
            
            CreateMap<Author, AuthorDto>();
        }
    }
}
