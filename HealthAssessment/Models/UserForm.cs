using System;
using System.Collections.Generic;

namespace HealthAssessment.Models
{
    public class UserForm
    {
        public virtual User User { get; set; }
        public int UserId { get; set; }
        public virtual Form Forms { get; set; }
        public int FormId { get; set; }
        public bool Check { get; set; }
    }
}
