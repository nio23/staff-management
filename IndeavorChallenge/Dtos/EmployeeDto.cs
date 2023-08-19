using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndeavorChallenge.Dtos
{
    public class EmployeeDto
    {
        public int id { get; set; }
        [Required]
        public string surname { get; set; }
        [Required]
        public string name { get; set; }
        public List<SkillDto> skills { get; set; }
        public DateTime hiringDate { get; set; }
    }
}