using AutoMapper;
using MongoDB.Bson;
using PumpData.Books;
using PumpData.RealTimeParam;
using System;

namespace PumpData
{
    public class PumpDataApplicationAutoMapperProfile : Profile
    {
        [Obsolete]
        public PumpDataApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<Parameter, ParameterDto>();
            CreateMap<CreateUpdateParameterDto, Parameter>();

            CreateMap<Book, BookDto>();
            CreateMap<CreateUpdateBooksDto,Book>();
                
        }
    }
}
