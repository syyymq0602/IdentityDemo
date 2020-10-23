using System;
using Volo.Abp.Application.Dtos;

namespace PumpData.FaultKnowledge
{
    public class FaultDto : EntityDto<Guid>
    {
        public double F_id { get; set; }
        public string F_type { get; set; }
        public string F_feature { get; set; }
        public string DecisionSupport { get; set; }
    }
}
