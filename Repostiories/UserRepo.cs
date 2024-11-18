using Microsoft.EntityFrameworkCore;
using Orders_Managment_System.Dtos;
using Orders_Managment_System.Interfaces;
using Orders_Managment_System.Models;

namespace Orders_Managment_System.Repostiories
{
    public class UserRepo : IUserRepositry
    {
        private readonly ApplicationDbContext _context;

        public UserRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateUserAsync(UserDto user)
        {
            var newuser = new User()
            {
                Name = user.Name,
                Password = user.Password,
                role = user.role
            };
            await _context.users.AddAsync(newuser);
            await _context.SaveChangesAsync();
        }

        public async Task<User> FindUserAsync(UserDto user)
        {
            var result = await _context.users.FirstOrDefaultAsync(x=>x.Name == user.Name && x.Password == user.Password);
            return result;
        }
    }
}
