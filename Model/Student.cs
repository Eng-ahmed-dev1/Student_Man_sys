using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Gradebook.Model
{
    class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int Grade {  get; set; }
        public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
        public Student(){}
        public Student(string name , int grade)
        {
            Name = name;
            Grade = grade;
        }
    }
}
