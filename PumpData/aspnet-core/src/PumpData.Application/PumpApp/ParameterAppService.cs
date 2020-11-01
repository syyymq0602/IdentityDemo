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

namespace PumpData.PumpApp
{
    public class ParameterAppService :
        CrudAppService<
            Parameter,
            ParameterDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateParameterDto>,
        IParameterAppService
    {
        public ParameterAppService(IRepository<Parameter, Guid> repository)
            : base(repository)
        {

        }
        public async Task<ParameterDto> FindParaAsync(DateTime input)
        {
            var paras = await Repository.GetListAsync();
            var para =  paras.FirstOrDefault(para => para.P_date == input);

            return ObjectMapper.Map<Parameter,ParameterDto>(para);
        }

        //protected override IQueryable<Parameter> ApplySorting(IQueryable<Parameter> query, PagedAndSortedResultRequestDto input)
        //{
        //  return base.ApplySorting(query, input);
        //}
        public override Task<PagedResultDto<ParameterDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return base.GetListAsync(input);
        }

        protected override IQueryable<Parameter> ApplyDefaultSorting(IQueryable<Parameter> query)
        {
            // Id排序为mongodb数据库顺序
            // var paras = query.OrderBy(para => para.Id);
            var paras = query.OrderBy(para => para.P_date);
            return paras;
        }
    }
}
