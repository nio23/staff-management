﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaffManagement.Dtos
{
    public class SkillCheckBox
    {
        public SkillDto skill { get; set; }
        public bool isChecked { set; get; }
    }
}