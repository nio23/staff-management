using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IndeavorChallenge.Models
{
    public class Skill
    {
        public int id { get; set; }
        public string name { get; set; }
        [Display(Name = "Created at")]
        public DateTime dateCreated { get; set; }
        public string description { get; set; }
    

    }
}