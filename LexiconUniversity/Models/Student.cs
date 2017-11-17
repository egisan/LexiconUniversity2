using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LexiconUniversity.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        public string FullName => (FirstName + " " + LastName).Trim();

        // navigational properties
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}