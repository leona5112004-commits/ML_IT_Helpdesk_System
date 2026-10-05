using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML_IT_Helpdesk.Models
{
    class Technician
    {
        public int TechnicianID { get; set; }
        public string TechnicianCode { get; set; }
        public string TechnicianName { get; set; }
        public string ContactPhone { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }  // Active, Inactive
    }
}
