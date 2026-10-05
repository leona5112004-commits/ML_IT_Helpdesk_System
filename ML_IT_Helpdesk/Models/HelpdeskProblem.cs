using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML_IT_Helpdesk.Models
{
    class HelpdeskProblem
    {
        public int ProblemNumber { get; set; }
        public int EmployeeID { get; set; }
        public int OperatorID { get; set; }
        public int? EquipmentID { get; set; }
        public int? SoftwareID { get; set; }
        public int? TechnicianID { get; set; }
        public string ProblemType { get; set; }      // Hardware, Software, Network
        public DateTime CallDateTime { get; set; }
        public string Reason { get; set; }
        public string ProblemDescription { get; set; }
        public string Status { get; set; }            // Open, In Progress, Closed
        public DateTime? ResolutionDateTime { get; set; }
        public string ResolutionDescription { get; set; }
        public decimal? ResolutionHours { get; set; }
    }
}
