using AutoMapper;
using PumpData.Books;
using PumpData.DiagnosticMessage;
using PumpData.EquipmentInformations;
using PumpData.FaultKnowledge;
using PumpData.RealTimeParam;
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
            CreateMap<Equipment, EquipmentDto>();
            CreateMap<CreateUpdateEquipmentDto, Equipment>();

            CreateMap<Diagnose, DiagnoseDto>();
            CreateMap<CreateUpdateDiagnoseDto,Diagnose>();

            CreateMap<Fault, FaultDto>();
            CreateMap<CreateUpdateFaultDto,Fault>();

            CreateMap<Parameter, ParameterDto>();
            CreateMap<CreateUpdateParameterDto,Parameter>();

            CreateMap<Book, BookDto>();
            CreateMap<CreateUpdateBooksDto,Book>();
                
        }
    }
}
