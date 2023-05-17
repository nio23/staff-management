using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IndeavorChallenge.Models
{
    public class Skill
    {
        public int id { get; set; }
        public string name { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Created at")]
        [Column(TypeName = "Date")]
        public DateTime dateCreated { get; set; }
        public string description { get; set; }

        public ICollection<Employee> employees { get; set; }

        public Skill()
        {
            dateCreated = DateTime.Today;
        }
    }
}