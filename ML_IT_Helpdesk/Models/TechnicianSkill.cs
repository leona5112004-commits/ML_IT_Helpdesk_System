using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML_IT_Helpdesk.Models
{
    class TechnicianSkill
    {
        public int TechnicianSkillID { get; set; }
        public int TechnicianID { get; set; }
        public int SkillID { get; set; }      
        public int SkillLevel { get; set; }
    }
}
