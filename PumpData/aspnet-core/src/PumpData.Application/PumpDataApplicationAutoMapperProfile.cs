using AutoMapper;
using MongoDB.Bson;
using PumpData.Books;
using PumpData.RealTimeParam;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PumpData
{
    public class PumpDataApplicationAutoMapperProfile : Profile
    {
        public PumpDataApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<Parameter, ParameterDto>()
                .ForMember(des => des.Time, opt => opt.MapFrom(
                    src => TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).Add(new TimeSpan(long.Parse(src.Id.ToString() + "0000000")))
                ));
                 //.ConvertUsing<CustomTypeConverter>();
            CreateMap<CreateUpdateParameterDto,Parameter>();

            CreateMap<Book, BookDto>();
            CreateMap<CreateUpdateBooksDto,Book>();
                
        }
    }
}
