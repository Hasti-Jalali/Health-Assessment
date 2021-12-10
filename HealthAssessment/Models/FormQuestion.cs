using System;
namespace HealthAssessment.Models
{
    public class FormQuestion
    {
        public int FormId { get; set; }
        public virtual Form Form { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
    }
}
