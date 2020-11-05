using System;
using Volo.Abp.Domain.Entities;

namespace PumpData.DiagnosticMessage
{
    public class Diagnose : AggregateRoot<Guid>
    {
        public double D_id { get; set; }
        public DateTime D_Date { get; set; }
        public string D_Result { get; set; }
        public string D_DecisionSupport { get; set; }
        public string StateInformation { get; set; }
    }
}
