using PumpData.Books;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;

namespace PumpData.Books
{
    public class BookService :
        CrudAppService<
              Book,
              BookDto,
              Guid,
              PagedAndSortedResultRequestDto,
              CreateUpdateBooksDto>,
          IBookService
    {
       public BookService(IRepository<Book, Guid> repository) : base(repository)
       {

       }
       public async Task<double> GetPressure(Guid pre)
       {
          var p = await Repository.GetAsync(pre);
          return p.GetProperty<double>("Pressure1");
       }

    }
}
