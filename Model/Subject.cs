﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Gradebook.Model
{
    class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }
        = new List<Student>();
        public Subject(){}
        public Subject(string name)
        {
              Name = name;
        }
    }
}