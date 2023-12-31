﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StaffManagement.Models
{
    public class Skill
    {

        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Created at")]
        [Column(TypeName = "Date")]
        public DateTime dateCreated { get; set; }
        public string description { get; set; }

        public virtual ICollection<Employee> employees { get; set; }

        public Skill()
        {
            dateCreated = DateTime.Today;
        }

        public string shortDateCreated { get => dateCreated.ToShortDateString(); }
    }
}