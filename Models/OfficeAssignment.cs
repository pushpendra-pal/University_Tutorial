using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace University.Models
{
    public class OfficeAssignment
    {
        [Key]
        public int InstructorID { get; set; }
        //The key attr can be used to explicitly use a column as PK

        [StringLength(50)]
        [Display(Name = "Office Location")]
        public string Location { get; set; }

        public Instructor Instructor { get; set; }
    }
}
