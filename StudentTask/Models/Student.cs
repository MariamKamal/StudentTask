using System;
using System.Collections.Generic;

namespace StudentTask.Models
{
    public partial class Student
    {
        public Student()
        {
            StudentTeacher = new HashSet<StudentTeacher>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int GovernorateId { get; set; }
        public int? NeighborhoodId { get; set; }
        public int FieldId { get; set; }

        public virtual Field Field { get; set; }
        public virtual Governorate Governorate { get; set; }
        public virtual Neighborhood Neighborhood { get; set; }
        public virtual ICollection<StudentTeacher> StudentTeacher { get; set; }
    }
}
