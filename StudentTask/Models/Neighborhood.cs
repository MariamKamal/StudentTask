using System;
using System.Collections.Generic;

namespace StudentTask.Models
{
    public partial class Neighborhood
    {
        public Neighborhood()
        {
            Student = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int GovernorateId { get; set; }

        public virtual Governorate Governorate { get; set; }
        public virtual ICollection<Student> Student { get; set; }
    }
}
