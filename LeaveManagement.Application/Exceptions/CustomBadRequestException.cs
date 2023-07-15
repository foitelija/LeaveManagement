using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Application.Exceptions
{
    public class CustomBadRequestException : ApplicationException
    {
        public CustomBadRequestException(string message) : base (message) { }
    }
}
