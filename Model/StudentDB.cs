using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Gradebook.Model
{
    class StudentsDB : DbContext
    {
        public StudentsDB(){}
        public StudentsDB(DbContextOptions<StudentsDB> options):base(options){ }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-2008HFE\\SQLEXPRESS;Initial Catalog=StudentDB;Integrated Security=True;Trust Server Certificate=True");
            }
        }

    }
    
}
