using Employees.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
namespace Employees.Data
{
    public class DataJsonEmployees
    {
        private readonly string _path = @"C:\DataJson\DataEmployees.json";

        public List<Employee> GetEmployees() 
         {
            var listEmployees = System.IO.File.ReadAllText(_path);
      
            return JsonConvert.DeserializeObject<List<Employee>>(listEmployees);

         }
        public bool SaveEmployees(object objDinamy)
        {
            System.IO.File.WriteAllText(_path,objDinamy.ToString());
            return true;

        }
       
    }
}
