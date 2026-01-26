using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeERP_.Application.Common.Options
{
    public class JwtOptions
    {
        public string Key { get; set; } = null!;
        public string Issuer { get; set; } = null!;
        public string Audience { get; set; } = null!;
        public int ExpiresInMinutes { get; set; }
    }
}
