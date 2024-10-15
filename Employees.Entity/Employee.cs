using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Entity
{
    public class Employee
    {
        [Required]
        public int employeeNumber { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        public string entryDate { get; set; }
        [Required]
        public string exitDate { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public string country { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public string birthday { get; set; }
        [Required]
        public string mobilePhone { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        public string eMail { get; set; }
        [Required]
        public string street { get; set; }
        [Required]
        public string district { get; set; }
        [Required]
        public string postalCode { get; set; }
        [Required]
        public List<object> additionalData { get; set; }
    }
}
