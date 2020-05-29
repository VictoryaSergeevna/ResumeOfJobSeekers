using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Dz_FluentBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            Applicant Victorya = new EmployeeBuilder().setSurname("Сушко").setName("Виктория").setCompany("Банк Форум").setAge(34).setPhone(9103206)
                .setEducation("Высшее экономическое").isMarried;
            Applicant OLga = new EmployeeBuilder().setSurname("Иванова").setName("Ольга").setCompany("нет").setAge(24).setPhone(9000000)
                 .setEducation("Высшее юридическое");
            WriteLine(Victorya);
            WriteLine();
            WriteLine(OLga);
        }
    }

    public class Applicant
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public int Age { get; set; }
        public long Phone { get; set; }
        public string Education { get; set; }
        public bool isMarried { get; set; }
        public Applicant() { }
        public Applicant(string surname, string name, string company, int age, long phone, string education, bool isMarried)
        {
            this.Surname = surname;
            this.Name = name;
            this.Company = company;
            this.Age = age > 0 ? age : 18;
            this.isMarried = isMarried;
        }
        public override string ToString()
        {
            return $" Фамилия: {Surname} \n Имя: {Name}\n Компания: {Company}\n Возвраст: {Age}\n Телефон (097): {Phone}\n Образование: {Education}\n" +
                $" Замужем?: {isMarried}\n";
        }
    }
    public class EmployeeBuilder
    {
        private Applicant applicant;
        public EmployeeBuilder()
        {
            applicant = new Applicant();
        }
        public EmployeeBuilder setSurname(string surname)
        {
            applicant.Surname = surname;
            return this;
        }
        public EmployeeBuilder setName(string name)
        {
            applicant.Name = name;
            return this;
        }
        public EmployeeBuilder setCompany(string company)
        {
            applicant.Company = company;
            return this;
        }
        public EmployeeBuilder setAge(int age)
        {
            applicant.Age = age > 0 ? age : 0;
            return this;
        }
        public EmployeeBuilder setPhone(long phone)
        {
            applicant.Phone = phone;
            return this;
        }
        public EmployeeBuilder setEducation(string education)
        {
            applicant.Education = education;
            return this;
        }
        public EmployeeBuilder isMarried
        {
            get
            {
                applicant.isMarried = true;
                return this;
            }
        }
        public static implicit operator Applicant(EmployeeBuilder employee)
        {
            return employee.applicant;
        }
    }

    class Employee : Applicant    {
        Applicant applicant;
        public static EmployeeBuilder CreateBuilder()
        {
            return new EmployeeBuilder();
        }
    }
}
