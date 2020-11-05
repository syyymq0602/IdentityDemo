using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PumpData.DiagnosticMessage
{
    public interface IDiagnoseAppService :
        ICrudAppService< //Defines CRUD methods
            DiagnoseDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateDiagnoseDto> //Used to create/update a book
    {
        Task<DiagnoseDto> FindDiagnoseAsync(double input);
    }
}
