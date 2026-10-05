using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML_IT_Helpdesk.Models
{
    class Equipment
    {
        public int EquipmentID { get; set; }
        public string SerialNumber { get; set; }
        public string EquipmentType { get; set; }
        public string Manufacturer { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int OfficeID { get; set; }
        public DateTime WarrantyStartDate { get; set; }
        public DateTime WarrantyEndDate { get; set; }
        public string WarrantyStatus { get; set; }  // Active / Expired
    }
}
