using Microsoft.EntityFrameworkCore;
using LearnRecordAPI.Models;
using System.Data;

namespace LearnRecordAPI.Data
{
    public class LearnRecordDBContext : DbContext
    {
        public LearnRecordDBContext(DbContextOptions<LearnRecordDBContext> options) : base(options)
        {
        }
        public DbSet<learnTopicAdmin> learnTopicAdmin { get; set; }
        public DbSet<learnSubtopicAdmin> learnSubtopicAdmin { get; set; }
        public DbSet<learnProgressTracker> learnProgressTracker { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<learnTopicAdmin>().ToTable("learnTopicAdmin");
            modelBuilder.Entity<learnSubtopicAdmin>().ToTable("learnSubtopicAdmin");
            modelBuilder.Entity<learnSubtopicAdmin>().HasKey(s => new { s.topicID, s.subtopicID });
            modelBuilder.Entity<learnProgressTracker>().ToTable("learnProgressTracker");
            modelBuilder.Entity<learnProgressTracker>().HasKey(s => new { s.subtopicID, s.processID });
        }

    }
}
