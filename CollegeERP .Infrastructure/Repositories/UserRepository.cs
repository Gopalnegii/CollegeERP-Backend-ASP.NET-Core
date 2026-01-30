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
            var userData = await _context.Users.Where(u => u.UserId == id && u.Status != 0).FirstOrDefaultAsync();
            return userData;
        }
        public async Task<User> AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            try
            {
            await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex) when (DbExceptionHelper.IsUniqueConstraintViolation(ex))
            {
                throw new AlreadyExistsException($"A user with email '{user.Email}' already exists.");
            }
            return user;
        }
        public async Task UpdateAsync(User user )
        {
            _context.Users.Update(user);
            try
            {
            await _context.SaveChangesAsync();
            }
            catch(DbUpdateException ex) when (DbExceptionHelper.IsUniqueConstraintViolation(ex))
            {
                throw new AlreadyExistsException($"a user with email '{user.Email}' already exists.");
            }
        }
        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(p=>p.Email==email && p.Status!=0);
        }
    }
}
