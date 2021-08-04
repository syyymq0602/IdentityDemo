using System;
using BooksAppStore.BooksContracts;
using BooksAppStore.BooksContracts.DTOs;
using BooksAppStore.DomainBooks;
using BooksAppStore.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace BooksAppStore.AppServices
{
    public class BookAppService:CrudAppService<
            Book, //The Book entity
            BookDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateBookDto>, //Used to create/update a book
        IBookAppService //implement the IBookAppService
    {
        public BookAppService(IRepository<Book, Guid> repository)
            : base(repository)
        {
            GetPolicyName = BooksAppStorePermissions.Books.Default;
            GetListPolicyName = BooksAppStorePermissions.Books.Default;
            CreatePolicyName = BooksAppStorePermissions.Books.Create;
            UpdatePolicyName = BooksAppStorePermissions.Books.Edit;
            DeletePolicyName = BooksAppStorePermissions.Books.Delete;
        }
    }
}