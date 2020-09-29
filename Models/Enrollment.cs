using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.Models
{
    public enum Grade { A,B,C,D,E,F}
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        // the primary key, only ID also works

        [DisplayFormat(NullDisplayText = "No Grade")]
        public Grade? Grade { get; set; }
        // Using enums for limited set of possible entries,
        // ? means it can be null

        public int CourseID { get; set; }
        public Course Course { get; set; }
        // Same as for students, one for one

        public int StudentID { get; set; }
        public Student Student { get; set; }
        /* The StudentID property is a foreign key, and the corresponding navigation property is Student. 
         * An Enrollment entity is associated with one Student entity, so the property contains a single Student entity.
        
         * EF Core interprets a property as a foreign key if it's named <navigation property name><primary key property name>.
         */ 
    }
}
