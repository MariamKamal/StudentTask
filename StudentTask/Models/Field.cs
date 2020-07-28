using System;
using System.Collections.Generic;

namespace StudentTask.Models
{
    public partial class Field
    {
        public Field()
        {
            Student = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Student> Student { get; set; }
    }
}
