using System;
namespace HealthAssessment.Models
{
    public class UserFormResult
    {
        public int Id { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }
        public virtual Form Form { get; set; }
        public int FormId { get; set; }
        public virtual Question Question { get; set; }
        public int QuestionId { get; set; }
        public int Result { get; set; }
    }
}
