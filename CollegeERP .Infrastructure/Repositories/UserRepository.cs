using CollegeERP.Domain.Data.Entities;
using CollegeERP.Domain.Exceptions;
using CollegeERP_.Application.Interfaces.Repositories;
using CollegeERP_.Infrastructure.Data.Context;
using CollegeERP_.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;

namespace CollegeERP_.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CollegeERPDbContext _context;
        public UserRepository( CollegeERPDbContext collegeERPDbContext)
            {
                _context = collegeERPDbContext;

            }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
           return await _context.Users.Where(u => u.Status != 0).ToListAsync();
        }
        public async Task<User?> GetByIdAsync(int id)
        {
            var userData = await _context.Users.Where(u=>u.UserId==id && u.Status!=0).FirstOrDefaultAsync();
            return userData;
        }
        public async Task<bool> EmailExistsAsync(string email, int? id = null)
        {
            return await _context.Users.AnyAsync(u => u.Email == email && u.Status != 0 && (id==null || id != u.UserId));
        }
        public async Task<User> AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task UpdateAsync(User user )
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(p=>p.Email==email && p.Status!=0);
        }
    }
}
