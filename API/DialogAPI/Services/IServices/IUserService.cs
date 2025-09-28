using DialogAPI.Models;
using DialogAPI.Models.DTOs;

namespace DialogAPI.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetAllUsers();
        UserDto? GetUserById(int id);
        UserDto RegisterUser(RegisterUserDto dto);
    }
}
