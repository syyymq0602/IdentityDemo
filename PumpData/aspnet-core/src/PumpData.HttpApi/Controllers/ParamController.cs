using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using PumpData.RealTimeParam;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace PumpData.Controllers
{
[Microsoft.AspNetCore.Mvc.Route("api/param")]
    public class ParamController : PumpDataController,IParameterAppService
    {
    [HttpPost]
        public Task<ParameterDto> CreateAsync(CreateUpdateParameterDto input)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public Task<ParameterDto> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public Task<PagedResultDto<ParameterDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public Task<ParameterDto> UpdateAsync(string id, CreateUpdateParameterDto input)
        {
            throw new NotImplementedException();
        }
    }
}
