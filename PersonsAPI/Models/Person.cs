﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonsAPI.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }
        public bool Disabled { get; set; }

    }
}
