using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PumpData.FaultKnowledge
{
    public interface IFaultAppService :
        ICrudAppService< //Defines CRUD methods
            FaultDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateFaultDto> //Used to create/update a book
    {
        Task<FaultDto> FindFaultAsync(double input);
    }
}
