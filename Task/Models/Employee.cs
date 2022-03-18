using System;
using System.Collections.Generic;
using System.Text;

namespace Task.Models
{
    class Employee : Person
    {
        public double SalaryOfHour { get; set; }
        public double WorkingHour { get; set; }

        public Employee(string name, string surname, int age, double salaryOfHour, double workingHour)
        {
            Name = name;
            Surname = surname;
            Age = age;
            SalaryOfHour = salaryOfHour;
            WorkingHour = workingHour;
        }

        public double CalculateSalary()
        {
            return SalaryOfHour * WorkingHour;
        }
    }
}
