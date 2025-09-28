using DialogAPI.Data;
using DialogAPI.Models.DTOs;
using DialogAPI.Models.Entities;
using DialogAPI.Services.Interfaces;
using System;

namespace DialogAPI.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            return _context.Users
                .Select(u => new UserDto
                {
                    Username = u.Username,
                    Email = u.Email
                })
                .ToList();
        }

        public UserDto? GetUserById(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return null;

            return new UserDto
            {
                Username = user.Username,
                Email = user.Email
            };
        }

        public UserDto RegisterUser(RegisterUserDto dto)
        {
            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                Password = dto.Password
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return new UserDto
            {
                Username = user.Username,
                Email = user.Email
            };
        }
    }
}
