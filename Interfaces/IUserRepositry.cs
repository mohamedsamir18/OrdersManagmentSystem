using Orders_Managment_System.Dtos;
using Orders_Managment_System.Models;

namespace Orders_Managment_System.Interfaces
{
    public interface IUserRepositry
    {
        Task CreateUserAsync(UserDto user);
        Task<User> FindUserAsync(UserDto user);
    }
}
