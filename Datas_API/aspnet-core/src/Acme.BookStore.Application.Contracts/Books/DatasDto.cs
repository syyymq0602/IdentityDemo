using Acme.BookStore.Books;
using System;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Books
{
    public class DatasDto : EntityDto<Guid>
    {
        public double datas { get; set; }
    }
}
