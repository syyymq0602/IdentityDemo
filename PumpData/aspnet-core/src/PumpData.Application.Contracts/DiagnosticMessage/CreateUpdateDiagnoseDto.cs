using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PumpData.DiagnosticMessage
{
    public class CreateUpdateDiagnoseDto 
    {
        [Required]
        public Double D_id { get; set; }
        public DateTime D_Date { get; set; }
        public string D_Result { get; set; }
        public string D_DecisionSupport { get; set; }
        public string StateInformation { get; set; }
    }
}
