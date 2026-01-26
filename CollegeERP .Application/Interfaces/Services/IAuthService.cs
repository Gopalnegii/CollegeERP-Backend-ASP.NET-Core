using CollegeERP_.Application.DTOs.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeERP_.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<LoginResponse> LoginAsync(LoginRequest request);
    }
}
