using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DepartmentSystem;

class Program
{
    static void Main()
    {
        /*
        Department testDep = new Department("Test", new DateTime(2000, 01, 01));
        for (int i = 0; i < 10; i++)
        {
            Random rand = new Random();
            string _firstName = $"Name{i}";
            string _lastName = $"Last_Name{i}";
            int _age = rand.Next(20, 50);
            int _salary = rand.Next(30000, 100000);
            int _totalProjects = rand.Next(0, 10);
            testDep.AddEmployee(_firstName, _lastName, _age, _salary, _totalProjects);
        }
        */
        var Dep1 = Department.ReadDepInfoFromJSON();
        Dep1.Sort();
        Dep1.WriteDepInfoJSON();


    }
}
