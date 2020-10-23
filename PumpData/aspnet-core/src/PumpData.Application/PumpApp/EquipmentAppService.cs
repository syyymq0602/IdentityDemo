using PumpData.EquipmentInformations;
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
    public class EquipmentAppService:
        CrudAppService<
            Equipment,
            EquipmentDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateEquipmentDto>,
        IEquipmentAppService
    {
        public EquipmentAppService(IRepository<Equipment, Guid> repository)
            : base(repository)
        {

        }
        public async Task<EquipmentDto> FindEquipmentAsync(double input)
        {
            var equipment = (await Repository.GetListAsync())
                .FirstOrDefault(equipment => equipment.E_id == input);

            return ObjectMapper.Map<Equipment, EquipmentDto>(equipment);
        }
    }
}
