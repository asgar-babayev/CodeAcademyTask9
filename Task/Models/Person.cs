using System;
using System.Collections.Generic;
using System.Text;

namespace Task.Models
{
    abstract class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }
}
