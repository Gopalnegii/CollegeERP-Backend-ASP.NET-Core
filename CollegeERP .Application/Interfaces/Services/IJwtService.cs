using CollegeERP.Domain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeERP_.Application.Interfaces.Services
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
