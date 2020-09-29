using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using University.Data;
using University.Models;

namespace University.Pages.Courses
{
    public class DepartmentNamePageModel: PageModel
    {
        public SelectList DeptNameSL { get; set; }

        public void PopulateDeptDropDownList(SchoolContext _context, object selectedDept = null)
        {
            var deptQuery = from d in _context.Departments orderby d.Name select d;

            DeptNameSL = new SelectList(deptQuery.AsNoTracking(), "DepartmentID", "Name", selectedDept);
        }
    }
}
