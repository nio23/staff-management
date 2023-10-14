using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StaffManagement.Dtos
{
    public class EmployeeDto
    {
        public int id { get; set; }
        [Required]
        [Display(Name ="Surname")]
        public string surname { get; set; }
        [Display(Name ="Name")]
        [Required]
        public string name { get; set; }
        public List<SkillDto> skills { get; set; }
        [Display(Name = "Hired At:")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime hiringDate { get; set; }


        public EmployeeDto()
        {
            hiringDate = DateTime.Today;
        }
    }

    
}