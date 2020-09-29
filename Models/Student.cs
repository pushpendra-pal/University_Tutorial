using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.Models
{
    public class Student
    {
        public int ID { get; set; }
        // EF Core automatically interprets a property named ID or classnameID as primarykey, and StudentID (classnameID) will be foreign key for Enrollments table

        [Required, StringLength(50), Display(Name="Last Name"), RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        public string LastName { get; set; }

        [Required, StringLength(50,ErrorMessage ="More than 50 characters not allowed"), Display(Name="First Name"), Column("FirstName"), RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        public string FirstName { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {//No extra column is created for Fullname
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        public ICollection<Enrollment> Enrollments { get; set; }
        //A student may be enrolled in multiple courses, so the list of that.
        // It is a NAVIGATION PROPERTY, which holds other entities related tot his entity
        // Can use other collection types, such as List<Enrollment> or HashSet<Enrollment>. 
        // When ICollection<Enrollment> is used, EF Core creates a HashSet<Enrollment> collection by default
    }
}
