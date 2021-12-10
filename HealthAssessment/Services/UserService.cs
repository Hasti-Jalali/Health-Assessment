using System;
using System.Collections.Generic;
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
        public List<FormQuestion> GetForm (GetForm getForm)
        {
            var form = _context.UserForms.Where(x => x.FormId == getForm.FormId && x.UserId == getForm.UserId);
            if (form.FirstOrDefault().Check)
            {
                throw new Exception("این فرم قبلا تکمیل شده است.");
            }
            return _context.FormQuestions.Where(x => x.FormId == getForm.FormId).ToList();
        }
        public List<UserFormResult> GetResult (GetForm getForm)
        {
            var form = _context.UserForms.Where(x => x.FormId == getForm.FormId && x.UserId == getForm.UserId);
            if (!form.FirstOrDefault().Check)
            {
                throw new Exception("این فرم هنوز تکمیل نشده است.");
            }
            return _context.UserFormResults.Where(x => x.FormId == getForm.FormId && x.UserId == getForm.UserId).ToList();
        }
        public async Task<bool> SaveResult(SaveResult saveResult)
        {
            var form = _context.UserForms.Where(x => x.FormId == saveResult.FormId && x.UserId == saveResult.UserId);
            if (form.FirstOrDefault().Check)
            {
                throw new Exception("این فرم قبلا تکمیل شده است.");
            }
            foreach(var x in saveResult.QuestionResults)
            {
                var userFormResult = new UserFormResult
                {
                    UserId = saveResult.UserId,
                    FormId = saveResult.FormId,
                    QuestionId = x.QuestionId,
                    Result = x.Result
                };
                _context.UserFormResults.Add(userFormResult);
                await _context.SaveChangesAsync();
            }
            return true;
        }


    }
}
