using Acme.BookStore.Books;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore
{
    public class BookAppService :
            
            CrudAppService<Datas, DatasDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateDataDto, CreateUpdateDataDto>, 

            IBookAppService
    {
        public BookAppService(IRepository<Datas,Guid> repository): base(repository)
        {

        }
        protected override IQueryable<Datas> ApplyPaging(IQueryable<Datas> query, PagedAndSortedResultRequestDto input)
        {
            input.SkipCount = 0;
            input.MaxResultCount = 10;
            query = query.OrderBy(data => data.Id);
            return base.ApplyPaging(query,input);
        }
        public override Task<DatasDto> CreateAsync(CreateUpdateDataDto input)
        {
            input.datas.CompareTo(0.0034);
            return base.CreateAsync(input);
        }
        public override Task<PagedResultDto<DatasDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return base.GetListAsync(input);
        }
    }
}
