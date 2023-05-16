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
        public string surname { get; set; }
        public string name { get; set; }
        public ICollection<Skill> skills{ get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime hiringDate { get; set; }

    }
}