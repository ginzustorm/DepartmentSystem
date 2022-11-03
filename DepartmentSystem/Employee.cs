using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentSystem
{
    public class Employee
    {
        public int Id { get; private set; }
        /// <summary>
        /// First name. 
        /// </summary>
        public string FirstName { get; private set; }
        /// <summary>
        /// Last name. 
        /// </summary>
        public string LastName { get; private set; }
        /// <summary>
        /// Age. 
        /// </summary>
        public int Age { get; private set; }
        /// <summary>
        /// Salary. 
        /// </summary>
        public int Salary { get; private set; }
        /// <summary>
        /// Total sum of projects. 
        /// </summary>
        public int TotalProjects { get; private set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="firstName">Name. </param>
        /// <param name="lastName">Second name. </param>
        /// <param name="age">Age. </param>
        /// <param name="salary">Salary. </param>
        /// <param name="totalProjects">Total sum of projects. </param>
        public Employee(string firstName, string lastName, int age, int salary, int totalProjects, int id)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
            TotalProjects = totalProjects;
            Id = id;
        }
    }
}
