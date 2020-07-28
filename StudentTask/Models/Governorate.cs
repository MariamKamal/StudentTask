using System;
using System.Collections.Generic;

namespace StudentTask.Models
{
    public partial class Governorate
    {
        public Governorate()
        {
            Neighborhood = new HashSet<Neighborhood>();
            Student = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Neighborhood> Neighborhood { get; set; }
        public virtual ICollection<Student> Student { get; set; }
    }
}
