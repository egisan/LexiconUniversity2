using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LexiconUniversity.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string CourseId { get; set; }

        public string Name { get; set; }
        public int Credits { get; set; }

        // navigational properties
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}