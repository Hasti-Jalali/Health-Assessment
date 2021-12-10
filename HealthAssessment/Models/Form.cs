using System;
using System.Collections.Generic;

namespace HealthAssessment.Models
{
    public class Form
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Title { get; set; }

        public virtual List<FormQuestion> FormQuestions { get; set; }
        public virtual List<UserFormResult> UserFormResult { get; set; }
        public virtual List<UserForm> UserForms { get; set; }
    }
}
