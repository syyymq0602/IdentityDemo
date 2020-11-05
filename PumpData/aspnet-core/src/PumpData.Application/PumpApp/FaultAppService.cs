using PumpData.FaultKnowledge;
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
    public class FaultAppService :
        CrudAppService<
            Fault,
            FaultDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateFaultDto>,
        IFaultAppService
    {
        public FaultAppService(IRepository<Fault, Guid> repository)
            : base(repository)
        {
            
        }
        public async Task<FaultDto> FindFaultAsync(double input)
        {
            var fault = (await Repository.GetListAsync())
                .FirstOrDefault(fault => fault.F_id==input);

            return ObjectMapper.Map<Fault,FaultDto>(fault);
        }
    }
}
