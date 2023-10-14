using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaffManagement.Dtos
{
    public class SkillDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime dateCreated { get; set; }
        public string description { get; set; }
        //public ICollection<EmployeeDto> employees { get; set; }
    }
} 