using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using IndeavorChallenge.Models;
using IndeavorChallenge.Dtos;

namespace IndeavorChallenge.ViewModels
{
    public class EmployeeViewModel
    {
        public EmployeeDto employeeDto { get; set; }
        [Display(Name = "Select employee skills")]
        public IEnumerable<SkillDto> allSkills { get; set; }

        public List<int> selectedSkills { get; set; }

        public List<SkillCheckBox> skillCheckBoxes { get; set; }

        public EmployeeViewModel(EmployeeDto employee, IEnumerable<SkillDto> allSkills, List<int> selectedSkills)
        {
            employeeDto = employee;
            this.allSkills = allSkills;
            this.selectedSkills = selectedSkills;
            skillCheckBoxes = initCheckBoxes();
        }

        public EmployeeViewModel() {
            skillCheckBoxes = new List<SkillCheckBox>();
        }

        private List<SkillCheckBox> initCheckBoxes()
        {
            List<SkillCheckBox> cb = new List<SkillCheckBox>();
            foreach(var item in allSkills)
            {
                cb.Add(new SkillCheckBox
                {
                    skill = item,
                    isChecked = false
                });

                if (selectedSkills.Contains(item.id))
                    cb[cb.Count - 1].isChecked = true;
                
            }

            return cb;
        } 
    }
}