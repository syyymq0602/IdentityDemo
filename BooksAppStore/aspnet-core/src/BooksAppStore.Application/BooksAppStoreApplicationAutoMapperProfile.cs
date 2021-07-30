using AutoMapper;
using BooksAppStore.BooksContracts.DTOs;
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
        }
    }
}
