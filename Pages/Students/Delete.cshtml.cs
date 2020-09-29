using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using University.Data;
using University.Models;

namespace University.Pages.Students
{
    public class DeleteModel : PageModel
    {
        private readonly University.Data.SchoolContext _context;

        public DeleteModel(University.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; }
        public string ErrorMsg { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await _context.Students
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id); //this line needs to be changed after changing StudentContext Student to Students

            if (Student == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMsg = "Delete failed. Try again";
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id); //this line needs to be changed after changing StudentContext Student to Students

            if (student == null)
            {
                ErrorMsg = "Item does not exist anymore.";
                return Page();
            }
            try
            {

                _context.Students.Remove(student);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }catch (DbUpdateException)
            {
                return RedirectToAction("./Delete", new { id, saveChangesError = true });
            }
        }
    }
}
