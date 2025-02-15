﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University.Data;
using University.Models;

namespace University.Pages.Courses
{
    public class EditModel : DepartmentNamePageModel
    {
        private readonly SchoolContext _context;

        public EditModel(SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Course Course { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)   return NotFound();
            

            Course = await _context.Courses
                .Include(c => c.Department).FirstOrDefaultAsync(m => m.CourseID == id);

            if (Course == null)
            {
                return NotFound();
            }
            PopulateDeptDropDownList(_context, Course.DepartmentID);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int ? id)
        {
            if (id == null) return NotFound();

            var courseToUpdate =await  _context.Courses.FindAsync(id);

            if (courseToUpdate == null) return NotFound();
            
            if (await TryUpdateModelAsync<Course>(courseToUpdate, 
                "course",
                c => c.Credits,
                c => c.DepartmentID,
                c => c.Title))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateDeptDropDownList(_context, courseToUpdate.DepartmentID);
            return Page();
        }
        /*
        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.CourseID == id);
        }*/
    }
}
