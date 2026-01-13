using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeERP.Domain.Exceptions
{
    public class DepartmentAlreadyExistsException:Exception
    {
        public DepartmentAlreadyExistsException(string name)
        : base($"Department '{name}' already exists.")
        {
        }
    }
}
