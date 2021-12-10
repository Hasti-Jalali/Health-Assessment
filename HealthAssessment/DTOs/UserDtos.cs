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

    public class GetForm
    {
        public int UserId { get; set; }
        public int FormId { get; set; }
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
        public List<QuestionResult> QuestionResults { get; set; }
    }
}
