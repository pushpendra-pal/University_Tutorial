using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using University.Data;
using University.Models;

namespace University.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly University.Data.SchoolContext _context;

        public CreateModel(University.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyStudent = new Student();
            // TryUpdateModel prevents overposting (security practice)
            if(await TryUpdateModelAsync<Student>(
                    emptyStudent, "student", s => s.FirstName, s => s.LastName, s => s.EnrollmentDate))
            {// Only the fields mentioned above are changed, no other field data can be posted.
                _context.Students.Add(emptyStudent); // Add method can not be asynchronous
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            return Page();
            
            
            /*if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Students.Add(Student); //this line needs to be changed after changing StudentContext Student to Students
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");*/
        }
    }
}
