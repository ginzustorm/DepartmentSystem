using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DepartmentSystem
{
    public class Department
    {
        /// <summary>
        /// Department name. 
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Foundation date. 
        /// </summary>
        public DateTime FoundDate { get; private set; }
        /// <summary>
        /// List of employees. 
        /// </summary>
        List<Employee> employees = new List<Employee>();

        public Department (string name, DateTime foundDate)
        {
            Name = name;
            FoundDate = foundDate;
        }

        /// <summary>
        /// Add employee method. 
        /// </summary>
        /// <param name="firstName">Employee first name. </param>
        /// <param name="lastName">Employee last name. </param>
        /// <param name="age">Employee age. </param>
        /// <param name="department">Employee department. </param>
        /// <param name="salary">Employee salary. </param>
        /// <param name="totalProjects">Employee total sum of projects. </param>
        /// <returns></returns>
        public bool AddEmployee (string firstName, string lastName, int age, int salary, int totalProjects)
        {
            int size = employees.Count + 1;
            var tempEmp = new Employee(firstName, lastName, age, salary, totalProjects, size);
            employees.Add(tempEmp);
            return true;
        }

        /// <summary>
        /// Remove employee from department. 
        /// </summary>
        /// <param name="id">Employee ID</param>
        /// <returns></returns>
        public bool RemoveEmployee (int id)
        {
            if (employees.Exists(x => x.Id == id)) 
            {
                int index = employees.FindIndex(x => x.Id == id);
                employees.RemoveAt(index);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Method to output data of department in JSON format. 
        /// </summary>
        public void WriteDepInfoJSON()
        {
            var array = new JArray();
            JObject mainTree = new JObject();

            foreach (Employee employee in employees)
            {
                JObject employeeInfo = new JObject();
                employeeInfo["first_name"] = employee.FirstName;
                employeeInfo["last_name"] = employee.LastName;
                employeeInfo["age"] = employee.Age;
                employeeInfo["salary"] = employee.Salary;
                employeeInfo["sum_of_projects"] = employee.TotalProjects;
                array.Add(employeeInfo);
            }

            mainTree["department_name"] = Name;
            mainTree["found_date"] = FoundDate;
            mainTree["employee_list"] = array;
            
            string json = mainTree.ToString();

            using (StreamWriter sw = new StreamWriter(@"departments.json"))
            {
                sw.Write(json);
            }
        }

        /// <summary>
        /// Method to read the department data from JSON file. 
        /// </summary>
        /// <returns></returns>
        public static Department ReadDepInfoFromJSON()
        {
            string json = File.ReadAllText(@"input_departments.json");
            string _name = JObject.Parse(json)["department_name"].ToString();
            DateTime _foundDate = DateTime.Parse(JObject.Parse(json)["found_date"].ToString());
            var department = new Department(_name, _foundDate);
            var employees = JObject.Parse(json)["employee_list"].ToArray();
            foreach(var emp in employees)
            {
                string _firstName = emp["first_name"].ToString();
                string _lastName = emp["last_name"].ToString();
                int _age = int.Parse(emp["age"].ToString());
                int _salary = int.Parse(emp["salary"].ToString());
                int _total_projects = int.Parse(emp["sum_of_projects"].ToString());

                department.AddEmployee(_firstName, _lastName, _age, _salary, _total_projects);
            }
            return department;
        }

        /// <summary>
        /// Sorting method by 2 fields (age, salary). 
        /// </summary>
        public void Sort()
        {
            // TODO: finish sorting method by choosing what fields to sort
            employees.Sort((x, y) =>
            {
                int result = decimal.Compare(y.Age, x.Age);
                if (result == 0)
                {
                    result = decimal.Compare(y.Salary, x.Salary);
                    if (result == 0) 
                    {
                        result = decimal.Compare(x.Age, y.Age);
                    }
                }
                return result;
            });
        }
    }
}
