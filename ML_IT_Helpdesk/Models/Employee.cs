using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML_IT_Helpdesk.Models
{
    public class Employee
    {  // Properties
        public int EmployeeID { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string ContactPhone { get; set; }
        public string Email { get; set; }
        public DateTime EmploymentStartDate { get; set; }
        public DateTime? EmploymentEndDate { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public int OfficeID { get; set; }
    }
}
