using System;
using System.Collections.Generic;

namespace StudentTask.Models
{
    public partial class StudentTeacher
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }

        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
