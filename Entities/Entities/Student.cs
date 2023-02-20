using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entities.Entities
{
    public partial class Student
    {
        public Student()
        {
            presenceInLessons = new HashSet<presenceInLessons>();
        }

        public decimal StudentId { get; set; }
        public string IdentitiyNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public decimal GroupId { get; set; }
        public bool? statusStudent { get; set; }

        public virtual Groups Group { get; set; }
        public virtual ICollection<presenceInLessons> presenceInLessons { get; set; }
    }
}
