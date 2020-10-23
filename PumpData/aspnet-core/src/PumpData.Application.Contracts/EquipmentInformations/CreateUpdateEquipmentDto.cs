using System;
using System.ComponentModel.DataAnnotations;

namespace PumpData.EquipmentInformations
{
    public class CreateUpdateEquipmentDto
    {
        [Required]
        public double E_id { get; set; }
        public string E_Name { get; set; }
        public string E_Brand { get; set; }
        public string E_Type { get; set; }
        public string E_Material { get; set; }
        public string E_Use { get; set; }
        public string E_InstallationSite { get; set; }
        [Required]
        public DateTime E_InstallationDate { get; set; }
        public string E_MaintenanceDate { get; set; }
        public string E_MaintenanceInformation { get; set; }
    }
}
