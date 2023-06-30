using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


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
        public virtual ICollection<Skill> skills{ get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        [Display(Name="Hired At: ")]
        public DateTime hiringDate { get; set; }

        public Employee()
        {
            hiringDate = DateTime.Today;
        }

    }
}