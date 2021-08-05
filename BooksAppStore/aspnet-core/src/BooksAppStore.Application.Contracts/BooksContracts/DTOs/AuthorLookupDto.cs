using System;
using Volo.Abp.Application.Dtos;

namespace BooksAppStore.BooksContracts.DTOs
{
    public class AuthorLookupDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}