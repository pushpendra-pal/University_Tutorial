using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace University.Models
{
    public class CourseAssignment
    {
        public int InstructorID { get; set; }
        public Instructor Instructor { get; set; }

        public int CourseID { get; set; }
        public Course Course { get; set; }

        /*CourseAssignment doesn't require a dedicated PK.
         * The InstructorID and CourseID properties function as a composite PK
         */ 
    }
}
