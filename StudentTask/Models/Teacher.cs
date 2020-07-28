using System;
using System.Collections.Generic;

namespace StudentTask.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            StudentTeacher = new HashSet<StudentTeacher>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual ICollection<StudentTeacher> StudentTeacher { get; set; }
    }
}
