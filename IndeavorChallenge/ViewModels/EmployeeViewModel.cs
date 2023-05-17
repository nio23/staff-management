using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using IndeavorChallenge.Models;

namespace IndeavorChallenge.ViewModels
{
    public class EmployeeViewModel
    {
        public Employee employee { get; set; }
        [Display(Name = "Select employee skills")]
        public List<Skill> skills { get; set; }
    }
}