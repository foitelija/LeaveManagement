﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Application.Exceptions
{
    public class CustomNotFoundException : ApplicationException
    {
        public CustomNotFoundException(string name, object key) : base($"{name} ({key}) was not found") { }
    }
}
