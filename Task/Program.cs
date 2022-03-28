using System;
using Task.Models;
using Task.Utilities.Exceptions;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string name = "", surname = "";
            int age = 0;
            double salaryOfHour = 0, workingHour = 0;
            double iqRank = 0, languageRank = 0;
            int choice;
            do
            {
            Start:
                try
                {
                    Console.WriteLine("Seçim edin: (0-Info)");
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ancaq rəqəm daxil edə bilərsiniz");
                    Console.WriteLine("------------------------------------");
                    goto Start;
                }
                switch (choice)
                {
                    case 0:
                        Console.WriteLine(@"1-Işçi maaşının hesablanması
2-Məktəbli ortalamasının hesablanması
3-Proqramı sonlandır");
                        break;
                    case 1:
                        InputEmployee(name, surname, age, ref workingHour, ref salaryOfHour);
                        Employee emp = new Employee(name, surname, age, workingHour, salaryOfHour);
                        Console.WriteLine($"Nəticə: {emp.CalculateSalary()} Azn");
                        Console.WriteLine("------------------------------------");
                        break;
                    case 2:
                        InputStudent(name, surname, age, ref iqRank, ref languageRank);
                        Student std = new Student(name, surname, age, iqRank, languageRank);
                        Console.WriteLine($"Nəticə: {iqRank + languageRank} Bal");
                        bool result = std.ExamResult();
                        StudentIsPass(result);
                        Console.WriteLine("------------------------------------");
                        break;
                    case 3:
                        Console.WriteLine("Program sonlandırıldı.");
                        break;
                    default:
                        Console.WriteLine("Yanlış məlumat daxil edildi.");
                        Console.WriteLine("------------------------------------");
                        break;
                }
            } while (choice != 3);
        }

        //Employee Input
        static void InputEmployee(string name, string surname, int age, ref double workingHour, ref double salaryOfHour)
        {
            CheckName(name);
            CheckSurname(surname);
            CheckEmployeeAge(age);
            CheckSalaryWorkingHour(ref workingHour, ref salaryOfHour);
        }

        //Student Input
        static void InputStudent(string name, string surname, int age, ref double mathPoint, ref double azLangPoint)
        {
            CheckName(name);
            CheckSurname(surname);
            CheckStudentAge(age);
            CheckMathPointInput(ref mathPoint);
            CheckAzLangPointInput(ref azLangPoint);
        }

        //Check Name
        static void CheckName(string name)
        {
        SetName:
            try
            {
                Console.Write("Ad daxil edin: ");
                name = Console.ReadLine().Trim().Replace(" ", String.Empty);
                if (String.IsNullOrEmpty(name) && String.IsNullOrWhiteSpace(name))
                    throw new NullEmptyWhiteSpaceException("Ad daxil etmək məcburidir");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto SetName;
            }
        }

        //Check Surname
        static void CheckSurname(string surname)
        {
        SetSurname:
            try
            {
                Console.Write("Soyad daxil edin: ");
                surname = Console.ReadLine().Trim().Replace(" ", String.Empty);
                if (String.IsNullOrEmpty(surname) && String.IsNullOrWhiteSpace(surname))
                    throw new NullEmptyWhiteSpaceException("Soyad daxil etmək məcburidir");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto SetSurname;
            }
        }

        //Check Employee Age
        static void CheckEmployeeAge(int age)
        {
        SetAge:
            Console.Write("Yaş daxil edin: ");
            try
            {
                age = Convert.ToInt32(Console.ReadLine());
                if (age < 18 || age > 65)
                    throw new NotAvailableException("Işləmək üçün uyğun yaşda deyilsiniz");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ancaq rəqəm daxil edə bilərsiniz");
                goto SetAge;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto SetAge;
            }
        }

        //Check Salary Working Of Hour
        static void CheckSalaryWorkingHour(ref double salaryOfHour, ref double workingHour)
        {
        Start:
            try
            {
                Console.Write("Aylıq iş saatını daxil edin: ");
                workingHour = Convert.ToDouble(Console.ReadLine());
                if (workingHour <= 0 || workingHour > 176 || (workingHour / 30) >= 8)
                    throw new NotAvailableException("Aylıq iş saatı 1 saatdan az 176 saatdan çox ola bilməz");

                Console.Write("Saat başı qazanılan maaşı daxil edin: ");
                salaryOfHour = Convert.ToDouble(Console.ReadLine());
                if (salaryOfHour <= 0 || (salaryOfHour * workingHour) < 250)
                    throw new NotAvailableException("Aylıq maaş 250 Azn-dən az ola bilməz");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ancaq rəqəm daxil edə bilərsiniz");
                goto Start;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto Start;
            }
        }

        //Check Student Age
        static void CheckStudentAge(int age)
        {
        SetAge:
            try
            {
                Console.Write("Yaş daxil edin: ");
                age = Convert.ToInt32(Console.ReadLine());
                if (age < 6 || age > 20)
                    throw new NotAvailableException("Uyğun yaş qeyd edin");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ancaq rəqəm daxil edə bilərsiniz");
                goto SetAge;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto SetAge;
            }
        }

        //Check Math Point Input
        static void CheckMathPointInput(ref double mathPoint)
        {
        SetMathPointInput:
            try
            {
                Console.Write("Riyaziyyat balını daxil edin: ");
                mathPoint = Convert.ToDouble(Console.ReadLine());
                if (mathPoint > 100 || mathPoint < 0)
                    throw new NotAvailableException("100-dən çox 0-dan az bal yaza bilməzsiniz");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ancaq rəqəm daxil edə bilərsiniz");
                goto SetMathPointInput;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto SetMathPointInput;
            }
        }

        //Check Az Language Point Input
        static void CheckAzLangPointInput(ref double azLangPoint)
        {
        SetAzLangPointInput:
            try
            {
                Console.Write("Ana dili balını daxil edin: ");
                azLangPoint = Convert.ToDouble(Console.ReadLine());
                if (azLangPoint > 100 || azLangPoint < 0)
                    throw new NotAvailableException("100-dən çox 0-dan az bal yaza bilməzsiniz");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ancaq rəqəm daxil edə bilərsiniz");
                goto SetAzLangPointInput;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto SetAzLangPointInput;
            }
        }

        //Student Is Pass Method
        static void StudentIsPass(bool result)
        {
            if (result)
                Console.WriteLine("Imtahandan kecdiniz");
            else
                Console.WriteLine("Kesildiniz");
        }
    }

}
