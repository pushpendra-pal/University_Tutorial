using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using University.Data;
using University.Models;

namespace University.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly University.Data.SchoolContext _context;

        public DetailsModel(University.Data.SchoolContext context)
        {
            _context = context;
        }

        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //To read teh enrollment data for the selected student
            Student = await _context.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            /*Student = await _context.Students.FirstOrDefaultAsync(m => m.ID == id); //this line needs to be changed after changing StudentContext Student to Students
            */
            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
