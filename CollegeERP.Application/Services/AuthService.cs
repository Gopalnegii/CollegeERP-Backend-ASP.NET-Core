using CollegeERP.Domain.Data.Entities;
using CollegeERP.Application.DTOs.Security;
using CollegeERP.Application.Interfaces.Repositories;
using CollegeERP.Application.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeERP.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IJwtService _jwtService;
        public AuthService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher, IJwtService jwtService)
        {
            _jwtService = jwtService;
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }
        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);

            if (user == null)
                throw new UnauthorizedAccessException("Invalid email or password.");

            var result = _passwordHasher.VerifyHashedPassword(
                user,
                user.PasswordHash,
                request.Password);

            if (result == PasswordVerificationResult.Failed)
                throw new UnauthorizedAccessException("Invalid email or password.");

            var token = _jwtService.GenerateToken(user);
            return new LoginResponse
            {
                Token = token,
                UserId = user.UserId,
                Email = user.Email,
                Role = user.Role.RoleName
            };
        }
    }
}
