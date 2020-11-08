using MongoDB.Bson;
using PumpData.RealTimeParam;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Linq;

namespace PumpData.PumpApp
{
    public class ParameterAppService :
        AbstractKeyCrudAppService<Parameter, ParameterDto, ParameterKey, PagedAndSortedResultRequestDto, CreateUpdateParameterDto, CreateUpdateParameterDto>
    {
        private readonly IAsyncQueryableProvider _providers;
        public ParameterAppService(IRepository<Parameter> repository, IAsyncQueryableProvider providers)
            : base(repository)
        {
            _providers = providers;
        }

        //public async Task<ParameterDto> FindParaAsync(DateTime input)
        //{
        //    var paras = await Repository.GetListAsync();
        //    var para =  paras.FirstOrDefault(para => para.P_date == input);

        //    return ObjectMapper.Map<Parameter,ParameterDto>(para);
        //}
        // 排序
        //protected override IQueryable<Parameter> ApplyDefaultSorting(IQueryable<Parameter> query)
        //{
        //    // Id排序为mongodb数据库顺序
        //    // var paras = query.OrderBy(para => para.Id);
        //    var paras = query.OrderBy(para => para.Id);
        //    return paras;
        //}


        protected override async Task DeleteByIdAsync(ParameterKey id)
        {
            var data = Repository.DeleteAsync(d => d.P_vibration_X == id.P_vibration_X );
            await data;
        }

        protected override async Task<Parameter> GetEntityByIdAsync(ParameterKey id)
        {
            return await _providers.FirstOrDefaultAsync(
                Repository.Where(d => d.P_vibration_X == id.P_vibration_X)
            );
        }

        protected override IQueryable<Parameter> ApplySorting(IQueryable<Parameter> query, PagedAndSortedResultRequestDto input)
        {
            input.SkipCount = 0;
            input.MaxResultCount = 12;
            query = query.OrderBy(p => p.Id);
            return query;
        }
    }
}
