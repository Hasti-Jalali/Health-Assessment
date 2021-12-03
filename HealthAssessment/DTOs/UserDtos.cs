using System;
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
}
