using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeERP.Domain.Exceptions
{
    public abstract class DomainException : Exception
    {
        protected DomainException(string message) : base(message)
        {
        }
    }
    public class DepartmentAlreadyExistsException:DomainException
    {

        public DepartmentAlreadyExistsException(string name)
        : base($"Department '{name}' already exists.")
        {
        }
    }
    public class ValidationException : DomainException
    {
        public IDictionary<string, string[]> Errors { get; }

        public ValidationException(IDictionary<string, string[]> errors)
            : base("Validation failed")
        {
            Errors = errors;
        }
    }
}
