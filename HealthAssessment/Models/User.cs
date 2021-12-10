using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace HealthAssessment.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Role { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }

        public virtual List<UserForm> UserForms { get; set; }
        public virtual List<UserFormResult> UserFormResult { get; set; }
    }
}
