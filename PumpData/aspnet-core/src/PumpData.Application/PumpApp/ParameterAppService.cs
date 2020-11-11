using MongoDB.Bson;
using PumpData.RealTimeParam;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Linq;

namespace PumpData.PumpApp
{

    public class ParameterAppService :
        CrudAppService<Parameter, ParameterDto, string, PagedAndSortedResultRequestDto, CreateUpdateParameterDto, CreateUpdateParameterDto>, IParameterAppService
    {
        public ParameterAppService(IRepository<Parameter, string> repository)
            : base(repository)
        {
            
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
        ////}
        //public override Task<ParameterDto> CreateAsync(CreateUpdateParameterDto input)
        //{
        //    return base.CreateAsync(input);
        //}



        //protected override IQueryable<Parameter> ApplySorting(IQueryable<Parameter> query, PagedAndSortedResultRequestDto input)
        //{
        //    query = query.OrderBy(p => p.Id);
        //    return query;
        //}
        //public override Task<PagedResultDto<ParameterDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        //{
        //    var para = Repository.FirstOrDefault(p => p.P_vibration_X == 1493);
        //    var convert = ObjectMapper.Map<Parameter,ParameterDto>(para);
        //    Console.WriteLine(convert.Time);
        //    return base.GetListAsync(input);
        //}
    }
}
