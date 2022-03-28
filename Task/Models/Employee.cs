using System;
using System.Collections.Generic;
using System.Text;

namespace Task.Models
{
    class Employee : Person
    {
        private double _salaryOfHour;
        private double _workingHour;
        private int _age;
        public double WorkingHour
        {
            get { return _workingHour; }
            set
            {

                if (value <= 176 || (value / 30) <= 8)
                    _workingHour = value;
            }
        }
        public double SalaryOfHour
        {
            get { return _salaryOfHour; }
            set
            {
                if ((value * _workingHour) >= 250)
                    _salaryOfHour = value;
            }
        }

        public override int Age
        {
            get { return _age; }
            set
            {
                if (value > 18 || value < 65)
                    _age = value;
            }
        }

        public Employee(string name, string surname, int age, double workingHour, double salaryOfHour)
        {
            Name = name;
            Surname = surname;
            Age = age;
            WorkingHour = workingHour;
            SalaryOfHour = salaryOfHour;
        }

        public double CalculateSalary()
        {
            return Math.Round(SalaryOfHour * WorkingHour, 2);
        }
    }
}
