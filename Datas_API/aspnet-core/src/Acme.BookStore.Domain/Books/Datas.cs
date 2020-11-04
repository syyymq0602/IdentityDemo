using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.Books
{
    public class Datas : AggregateRoot<Guid>
    {
        public double datas { get; set; }
    }
}
