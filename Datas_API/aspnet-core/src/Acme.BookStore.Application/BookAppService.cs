using Acme.BookStore.Books;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Linq;

namespace Acme.BookStore
{
    public class BookAppService :
            AbstractKeyCrudAppService<Datas, DatasDto, DataKey, PagedResultRequestDto, CreateUpdateDataDto, CreateUpdateDataDto>
    {
        private readonly IAsyncQueryableProvider _providers;
        public BookAppService(IRepository<Datas> repository, IAsyncQueryableProvider providers) : base(repository)
        {
            _providers = providers;
        }
        
        
        protected override async Task DeleteByIdAsync(DataKey id)
        {
            var data = Repository.DeleteAsync(d => d.datas == id.data);
            await data;
        }
        
        protected override async Task<Datas> GetEntityByIdAsync(DataKey id)
        {
            return await _providers.FirstOrDefaultAsync(
                Repository.Where(d => d.datas == id.data)
            );
        }
    }
}
