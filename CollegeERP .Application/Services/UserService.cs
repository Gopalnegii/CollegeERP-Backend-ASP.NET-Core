using CollegeERP_.Application.DTOs.User;
using CollegeERP_.Application.Interfaces.Repositories;
using CollegeERP_.Application.Interfaces.Services;

namespace CollegeERP_.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository userRepository)
        {
            _repository = userRepository;
        }
        public async Task<IEnumerable<UserResponse>> GetAllAsync()
        {
               var users = await _repository.GetAllAsync();
            return users.Select(user => new UserResponse
            {
                UserId = user.UserId,
                Email = user.Email,
                
                RoleId = user.RoleId
            });
        }
        public async Task<UserResponse> GetByIdAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with id {id} not found.");
            }
            return new UserResponse
            {
                UserId = user.UserId,
                Email = user.Email,
                RoleId = user.RoleId
            };
        }
    }
}
