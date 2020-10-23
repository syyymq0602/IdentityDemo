using System;
using Volo.Abp.Application.Dtos;

namespace PumpData.DiagnosticMessage
{
    public class DiagnoseDto : EntityDto<Guid>
    {
        public Double D_id { get; set; }
        public DateTime D_Date { get; set; }
        public string D_Result { get; set; }
        public string D_DecisionSupport { get; set; }
        public string StateInformation { get; set; }
    }
}
