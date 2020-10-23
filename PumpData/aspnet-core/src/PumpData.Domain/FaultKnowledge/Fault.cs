using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace PumpData.FaultKnowledge
{
    public class Fault : AggregateRoot<Guid>
    {
        public double F_id { get; set; }
        public string F_type { get; set; }
        public string F_feature { get; set; }
        public string DecisionSupport { get; set; }
    }
}
