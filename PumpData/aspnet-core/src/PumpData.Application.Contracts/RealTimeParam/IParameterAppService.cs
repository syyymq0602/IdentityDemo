using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PumpData.RealTimeParam
{
    public interface IParameterAppService :
        ICrudAppService< //Defines CRUD methods
            ParameterDto, //Used to show books
            string, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateParameterDto> //Used to create/update a book
    {
        //Task<ParameterDto> FindParaAsync(DateTime input);
    }
}
