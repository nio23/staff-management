using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using StaffManagement.Dtos;
using System.Diagnostics;

namespace StaffManagement.ViewModels
{
    public class EmployeeViewModel
    {
        public EmployeeDto employeeDto { get; set; }
        [Display(Name = "Select employee skills")]
        public IEnumerable<SkillDto> allSkills { get; set; }

        public List<int> selectedSkills { get; set; }

        public List<SkillCheckBox> skillCheckBoxes { get; set; }

        public EmployeeViewModel(EmployeeDto employee, IEnumerable<SkillDto> allSkills)
        {
            employeeDto = employee;
            this.allSkills = allSkills;
            Debug.WriteLine("Allskills Count "+allSkills.Count());
            skillCheckBoxes = allSkills
                .Select(x => new SkillCheckBox {
                    skill = x,
                    isChecked = employee.skills !=null && employee.skills
                        .Select(m => m.id)
                        .Contains(x.id)                    
                })
                .ToList();

        }

        public EmployeeViewModel() {  }



   
    }
}