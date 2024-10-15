using Employees.Business;
using Employees.Data;
using Employees.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WebApiEmployees.Controllers;

namespace TestProject.Employees
{
    [TestClass]
    public class EmployeesTest
    {
        [TestMethod]
        public void GetListEmployee()
        {
            int employeenumber = 1200;
            var Response = new LogicEmployees().GetEmployee(employeenumber);
            Assert.AreEqual(200, Response.Result.Code);

        }

        [TestMethod]
        public void AgregateEmployees()
        {
            // var Response = new DataJsonEmployees().GetEmployees();
            var objEmpl = new Employee();
            objEmpl.employeeNumber = 1200;
            objEmpl.firstName = "Parra";
            var Response = new LogicEmployees().AddEmployee(objEmpl);

            Assert.AreEqual(201,Response.Result.Code);
        }
        [TestMethod]
        public void DeleteEmployees()
        {
            int employeenumber = 1200;
            var Response = new LogicEmployees().DeleteEmployee(employeenumber);

            Assert.AreEqual(200, Response.Result.Code);
        }

        [TestMethod]
        public void UpdateEmployees()
        {
            // var Response = new DataJsonEmployees().GetEmployees();
            var objEmpl = new Employee();
            objEmpl.employeeNumber = 1200;
            objEmpl.firstName = "Parra";
            var Response = new LogicEmployees().UpdateEmployee(objEmpl);

            Assert.AreEqual(201, Response.Result.Code);
        }
    }
}
