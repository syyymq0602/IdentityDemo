using PumpData.RealTimeParam;
using System;
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
            var para = (await Repository.GetListAsync())
                .FirstOrDefault(para => para.P_date == input);

            return ObjectMapper.Map<Parameter,ParameterDto>(para);
        }
    }
}
