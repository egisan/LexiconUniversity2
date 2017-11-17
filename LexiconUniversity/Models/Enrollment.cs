using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LexiconUniversity.Models
{
    public class Enrollment
    {
        public int Id { get; set; }

        [Index("IX_CourseAndStudent", 1, IsUnique = true)]
        public string CourseId { get; set; }
       
        [Index("IX_CourseAndStudent", 2, IsUnique = true)]
        public int StudentId { get; set; }

        public Grade? Grade { get; set; }

        // navigational properties
        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }

    public enum Grade
    {
        A, B, C, F, D
    }
}