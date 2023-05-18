using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace IndeavorChallenge.Models
{
    public class Employee
    {
        public int id { get; set; }
        [Required]
        [Display(Name= "Surname")]
        public string surname { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string name { get; set; }
        public ICollection<Skill> skills{ get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        [Display(Name="Hired At")]
        public DateTime hiringDate { get; set; }

        public Employee()
        {
            hiringDate = DateTime.Today;
        }

    }
}