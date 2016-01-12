using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrmDemo.Models
{
    public class OperationResult<T>
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
