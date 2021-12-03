using System;
using System.Linq;
using System.Threading.Tasks;
using HealthAssessment.DTOs;
using HealthAssessment.Models;
using Microsoft.AspNetCore.Mvc;
using BCryptNet = BCrypt.Net.BCrypt;

namespace HealthAssessment.Services
{
    public class UserService
    {
        private readonly DBContext _context;

        public UserService(DBContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<UserDtos>> CreateUser(UserDtos user)
        {
            if (_context.Users.Where(x => x.Username == user.Username).Count() > 0)
                throw new Exception("این نام کاربری در سیستم وجود دارد.");
            var newUser = new User
            {
                Username = user.Username,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PasswordHash = BCryptNet.HashPassword(user.Password)

            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return user;
        }
        public bool LoginUser(Login user)
        {
            var _user = _context.Users.Where(x => x.Username == user.Username);
            if (_user != null)
            {
                if (_user.FirstOrDefault().PasswordHash == BCryptNet.HashPassword(user.Password))
                    return true;
                else
                    throw new Exception("رمز وارد شده اشتباه است.");
            }
            else
                throw new Exception("نام کاربری وارد شده نادرست است.");
        }
    }
}
