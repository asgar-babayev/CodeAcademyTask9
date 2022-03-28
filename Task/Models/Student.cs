using System;
using System.Collections.Generic;
using System.Text;

namespace Task.Models
{
    class Student : Person
    {
        private double _iqRank;
        private double _languageRank;
        private int _age;
        public double IQRank
        {
            get
            {
                return _iqRank;
            }
            set
            {
                if (value >= 0 || value <= 100)
                {
                    _iqRank = value;
                }
            }
        }
        public double LanguageRank
        {
            get
            {
                return _languageRank;
            }
            set
            {
                if (value >= 0 || value <= 100)
                {
                    _languageRank = value;
                }
            }
        }
        public override int Age
        {
            get { return _age; }
            set
            {
                if (value > 6 || value < 20)
                    _age = value;
            }
        }


        public Student(string name, string surname, int age, double iqRank, double languageRank)
        {
            Name = name;
            Surname = surname;
            Age = age;
            IQRank = iqRank;
            LanguageRank = languageRank;
        }

        public bool ExamResult()
        {
            if (IQRank + LanguageRank >= 120)
                return true;
            return false;
        }
    }
}
