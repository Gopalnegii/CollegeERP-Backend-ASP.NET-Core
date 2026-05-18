using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeERP.Application.DTOs
{
    public class ApiErrorResponse
    {
        public string Error { get; set; } = string.Empty;
        public int Status { get; set; }
        public object? Details { get; set; }
        public string traceId { get; set; } = string.Empty;
    }
}
