using System;
using BooksAppStore.BooksContracts.DTOs;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BooksAppStore.BooksContracts
{
    public interface IBookAppService:
        ICrudAppService< //Defines CRUD methods
            BookDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateBookDto> //Used to create/update a book
    {
        
    }
}