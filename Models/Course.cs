using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace University.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None), Display(Name ="Number")]
        public int CourseID { get; set; }
        //The database does not automatically generate ID values(primary key), rather it needs to be specified

        [StringLength(50,MinimumLength =3)]
        public string Title { get; set; }

        [Range(0,5)]
        public int Credits { get; set; }

        public int DepartmentID { get; set; }
        /* The Course entity has a foreign key (FK) property DepartmentID. 
         * DepartmentID points to the related Department entity. 
         * The Course entity has a Department navigation property.
         */ 
        public Department Department { get; set; }
        public HashSet<Enrollment> Enrollments { get; set; }
        // Using Hashset here instead of Collection interface, both works

        public ICollection<CourseAssignment> CourseAssignments { get; set; }
    }
}
