using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Application.Exceptions
{
    public class CustomValidationException : ApplicationException
    {
        public List<string> Erorrs { get; set; } = new List<string>();

        public CustomValidationException(ValidationResult validationResult) 
        {
            foreach(var item in validationResult.Errors)
            {
                Erorrs.Add(item.ErrorMessage);
            }
        }
    }
}
