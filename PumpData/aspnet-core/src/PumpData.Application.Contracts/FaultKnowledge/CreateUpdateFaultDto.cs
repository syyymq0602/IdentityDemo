using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PumpData.FaultKnowledge
{
    public class CreateUpdateFaultDto
    {
        [Required]
        public double F_id { get; set; }
        public string F_type { get; set; }
        public string F_feature { get; set; }
        public string DecisionSupport { get; set; }
    }
}
