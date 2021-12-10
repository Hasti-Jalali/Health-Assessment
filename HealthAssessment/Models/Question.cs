using System;
using System.Collections.Generic;

namespace HealthAssessment.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public virtual List<FormQuestion> FormQuestions { get; set; }
        public virtual List<UserFormResult> UserFormResult { get; set; }
    }
}
