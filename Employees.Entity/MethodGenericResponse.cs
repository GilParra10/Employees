using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Entity
{
    public class MethodGenericResponse<T>
    {
        public int  Code { get; set; }
        public string Message { get; set; }
        public T MethodResult { get; set; }
    }
}
