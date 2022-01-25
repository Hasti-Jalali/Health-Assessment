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
            if(_context.Users.Where(x => x.Email == user.Email).Count() > 0)
                throw new Exception("این ایمیل در سیستم وجود دارد.");
            var newUser = new User
            {
                Username = user.Username,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PasswordHash = user.Password

            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return user;
        }
        public LoginResponse LoginUser(Login user)
        {
            var _user = _context.Users.Where(x => x.Username == user.Username);
            if (_user.Count() > 0)
            {
                if (_user.FirstOrDefault().PasswordHash == user.Password)
                    return new LoginResponse {
                        Role = _user.FirstOrDefault().Role,
                        UserId = _user.FirstOrDefault().Id,
                        Status = true,
                        FName = _user.FirstOrDefault().FirstName,
                        LName = _user.FirstOrDefault().LastName
                    };
                else
                    throw new Exception("رمز وارد شده اشتباه است.");
            }
            else
                throw new Exception("نام کاربری وارد شده نادرست است.");
        }
        public GetFormResponse GetForm (GetForm getForm)
        {
            var form = _context.UserForms.Where(x => x.FormId == getForm.FormId && x.UserId == getForm.UserId);
            if (form != null && form.FirstOrDefault().Check)
            {
                throw new Exception("این فرم قبلا تکمیل شده است.");
            }
            var questions = _context.FormQuestions.Where(x => x.FormId == getForm.FormId).ToList();
            questions.Sort((x, y) => x.QuestionId.CompareTo(y.QuestionId));
            var Qlist = new List<string>();
            foreach(var q in questions)
            {
                Qlist.Add(q.Question.Text);
            }

            var result = new GetFormResponse
            {
                Questions = Qlist
            };
            return result;
        }
        public List<GetResultResponse> GetResult (GetForm getForm)
        {
            var form = _context.UserForms.Where(x => x.FormId == getForm.FormId && x.UserId == getForm.UserId);
            if (form!= null && !form.FirstOrDefault().Check)
            {
                throw new Exception("این فرم هنوز تکمیل نشده است.");
            }
            var result = new List<GetResultResponse>();
            var ufrs = _context.UserFormResults.Where(x => x.FormId == getForm.FormId && x.UserId == getForm.UserId).ToList();
            ufrs.Sort((x, y) => x.QuestionId.CompareTo(y.QuestionId));
            foreach(var ufr in ufrs)
            {
                result.Add(new GetResultResponse
                {
                    Question = ufr.Question.Text,
                    Answer = ufr.Result
                });
            }
            return result;
        }
        public async Task<bool> SaveResult(SaveResult saveResult)
        {
            var form = _context.UserForms.Where(x => x.FormId == saveResult.FormId && x.UserId == saveResult.UserId).FirstOrDefault();
            
            if (form.Check)
            {
                throw new Exception("این فرم قبلا تکمیل شده است.");
            }
            form.Check = true;
            await _context.SaveChangesAsync();
            var questions = _context.FormQuestions.Where(x => x.FormId == saveResult.FormId)
                .Select(x=> x.QuestionId).ToList();
            questions.Sort();
            var i = 0;
            foreach (var q in questions)
            {
                var ufr = new UserFormResult
                {
                    FormId = saveResult.FormId,
                    UserId = saveResult.UserId,
                    QuestionId = q,
                    Result = saveResult.QuestionResults[i]
                };
                i++;
                _context.UserFormResults.Add(ufr);
                await _context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> ChangePassword(ChangePassword request)
        {
            var user = _context.Users.Where(x => x.Username == request.UserName).FirstOrDefault();
            if(user.PasswordHash == request.OldPassword)
            {
                user.PasswordHash = request.NewPassword;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("پسورد ورودی با پسورد قبلی همخوانی ندارد!");
            }
            return true;
        }
    }
}
