using Employees.Data;
using Employees.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Business
{
    public class LogicEmployees
    {
        public Task<MethodGenericResponse<List<Employee>>> GetEmployee(int employeenumber)

        {
            try
            {
                var getAllEmployees = new DataJsonEmployees().GetEmployees().ToList();
                var getListEmploye = getAllEmployees.Where(emp => emp.employeeNumber == employeenumber).ToList();
                if (getListEmploye.Count == 0)
                {
               
                    return Task.FromResult(new MethodGenericResponse<List<Employee>> {MethodResult = getAllEmployees, Code = (int)HttpStatusCode.OK, Message= "Employee data is obtained correctly" });
                }
                return Task.FromResult(new MethodGenericResponse<List<Employee>> { MethodResult = getListEmploye, Code = (int)HttpStatusCode.OK, Message = "All employee data is obtained" });

            }
            catch (Exception ex)
            {
                return Task.FromResult(new MethodGenericResponse<List<Employee>> { MethodResult = null, Code = (int)HttpStatusCode.BadRequest, Message = $"Error obtaining employee data {ex.Message}" });
            }
            
        }
        public Task<MethodGenericResponse<bool>> UpdateEmployee(Employee employee)

        {
            try
            {
                List<Employee> updaEmployees = new List<Employee>();
                if (employee != null)
                {

                    var getEmploye = new DataJsonEmployees().GetEmployees().ToList();

                    foreach (var item in getEmploye)
                    {
                        if (item.employeeNumber == employee.employeeNumber)
                        {
                            item.firstName = employee.firstName;
                            item.lastName = employee.lastName;
                            item.entryDate = employee.entryDate;
                            item.exitDate = employee.exitDate;
                            item.city = employee.city;
                            item.country = employee.country;
                            item.description = employee.description;
                            item.gender = employee.gender;
                            item.birthday = employee.birthday;
                            item.mobilePhone = employee.mobilePhone;
                            item.phone = employee.phone;
                            item.eMail = employee.eMail;
                            item.street = employee.street;
                            item.district = employee.district;
                            item.postalCode = employee.postalCode;
                            item.additionalData = employee.additionalData;
                        }
                        updaEmployees.Add(item);
                    }
                    string employeeData = JsonConvert.SerializeObject(updaEmployees);
                    var response = new DataJsonEmployees().SaveEmployees(employeeData);
                }

                return Task.FromResult(new MethodGenericResponse<bool> {MethodResult = true, Code = (int)HttpStatusCode.Created, Message = "Employee data was successfully updated" });
            }
            catch(Exception ex)
            {

                return Task.FromResult(new MethodGenericResponse<bool> { MethodResult = false, Code = (int)HttpStatusCode.InternalServerError, Message = $"Error updating employee data{ex.Message}" });
            }
            
        }
        public Task<MethodGenericResponse<bool>> DeleteEmployee(int employeenumber)

        {
            try
            {
                List<Employee> updaEmployees = new List<Employee>();


                var getEmploye = new DataJsonEmployees().GetEmployees().ToList();

                foreach (var item in getEmploye)
                {
                    if (item.employeeNumber != employeenumber)
                    {
                        updaEmployees.Add(item);
                    }
                    
                }
                string employeeData = JsonConvert.SerializeObject(updaEmployees);
                var response = new DataJsonEmployees().SaveEmployees(employeeData);


                return Task.FromResult(new MethodGenericResponse<bool> { MethodResult = true, Code = (int)HttpStatusCode.OK, Message = "Employee data was successfully Delete" });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new MethodGenericResponse<bool> { MethodResult = false, Code = (int)HttpStatusCode.InternalServerError, Message = $"Error Delete employee data{ex.Message}" });
            }
           
        }

        public Task<MethodGenericResponse<bool>> AddEmployee(Employee employee)
        {
            try
            {
                if (employee != null)
                {
                    var getListEmp = new DataJsonEmployees().GetEmployees();

                    getListEmp.Add(employee);
                    string employeeData = JsonConvert.SerializeObject(getListEmp);
                    var response = new DataJsonEmployees().SaveEmployees(employeeData);
                }

                return Task.FromResult(new MethodGenericResponse<bool> { MethodResult = true, Code = (int)HttpStatusCode.Created, Message = "Employee data was successfully Agregate" });
            }
            catch (Exception ex) 
            {
                return Task.FromResult(new MethodGenericResponse<bool> { MethodResult = false, Code = (int)HttpStatusCode.InternalServerError,  Message = $"Error Agregate employee data{ex.Message}" });
            }
           
        }
    }
}
