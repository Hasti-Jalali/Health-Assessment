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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Debugger.Launch();
            base.OnModelCreating(builder);
            builder.Entity<User>().HasKey(e => e.Id);
        }
    }
}

