using PumpData.DiagnosticMessage;
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
    public class DiagnoseAppService :
        CrudAppService<
            Diagnose,
            DiagnoseDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateDiagnoseDto>,
        IDiagnoseAppService
    {
        public DiagnoseAppService(IRepository<Diagnose, Guid> repository)
            : base(repository)
        {

        }
        public async Task<DiagnoseDto> FindDiagnoseAsync(double input)
        {
            var diagnose = (await Repository.GetListAsync())
               .FirstOrDefault(diagnose => diagnose.D_id == input);

            return ObjectMapper.Map<Diagnose, DiagnoseDto>(diagnose);
        }

        public async Task UpdateDiaAsync(Guid id, CreateUpdateDiagnoseDto input)
        {
            var dia = await Repository.GetAsync(id);
            //Automatically set properties of the user object using the UpdateUserInput
            ObjectMapper.Map(input,dia);
            await Repository.UpdateAsync(dia);
        }
    }
}
