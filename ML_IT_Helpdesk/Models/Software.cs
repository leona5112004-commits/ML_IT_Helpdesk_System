using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML_IT_Helpdesk.Models
{
    class Software
    {
        public int SoftwareID { get; set; }
        public string SoftwareName { get; set; }
        public string Version { get; set; }
        public string LicenceNumber { get; set; }
        public DateTime LicenceStartDate { get; set; }
        public DateTime LicenceEndDate { get; set; }
        public string LicenceStatus { get; set; } // Active / Expired
        public int? EquipmentID { get; set; }
    }
}
