using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace IndeavorChallenge.Models
{
    public class Employee
    {
        public int id { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public List<Skill> skills { get; set; }
        public DateTime hiringDate { get; set; }

    }
}