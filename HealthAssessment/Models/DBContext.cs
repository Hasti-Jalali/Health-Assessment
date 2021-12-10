using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace HealthAssessment.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base (options)
        {
        }

        public DBContext() { }

        public DbSet<User> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<UserForm> UserForms { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<UserFormResult> UserFormResults { get; set; }
        public DbSet<FormQuestion> FormQuestions { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            Debugger.Launch();
            base.OnModelCreating(builder);
            builder.Entity<User>().HasKey(e => e.Id);
            builder.Entity<Question>().HasKey(e => e.Id);
            builder.Entity<UserForm>().HasKey(e => new { e.UserId, e.FormId});
            builder.Entity<Form>().HasKey(e => e.Id);
            builder.Entity<UserFormResult>().HasKey(e => e.Id);
            builder.Entity<FormQuestion>().HasKey(e => new { e.QuestionId, e.FormId });
        }
    }
}

