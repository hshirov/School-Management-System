using Data.Models;
using System.Data.Entity;

namespace Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext() : base("name=SchoolDb") { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<SchoolDbContext>(null);
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}
