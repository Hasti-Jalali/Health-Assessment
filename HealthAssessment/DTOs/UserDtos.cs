using System;
using System.Collections.Generic;
using HealthAssessment.Models;

namespace HealthAssessment.DTOs
{
    public class UserDtos
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Role { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

    }

    public class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponse
    {
        public bool Status { get; set; }
        public int UserId { get; set; }
        public int Role { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
    }


    public class GetForm
    {
        public int UserId { get; set; }
        public int FormId { get; set; }
    }

    public class GetFormResponse
    {
        public List<string> Questions { get; set; }
    }

    public class GetResultResponse
    {
        public string Question { get; set; }
        public int Answer { get; set; }
    }
    public class QuestionResult
    {
        public int QuestionId { get; set; }
        public int Result { get; set; }

    }
    public class SaveResult
    {
        public int UserId { get; set; }
        public int FormId { get; set; }
        public List<int> QuestionResults { get; set; }
    }

    public class ChangePassword
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string UserName { get; set; }
    }

}
