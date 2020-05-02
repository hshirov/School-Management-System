using Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
