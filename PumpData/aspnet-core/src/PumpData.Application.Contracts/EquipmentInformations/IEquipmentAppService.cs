using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PumpData.EquipmentInformations
{
    public interface IEquipmentAppService :
        ICrudAppService< //Defines CRUD methods
            EquipmentDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateEquipmentDto> //Used to create/update a book
    {
        Task<EquipmentDto> FindEquipmentAsync(double input);
    }
}
