using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class Teacher_CoursesManagementController : Controller
    {
        private readonly WebApplication2Context _context;

        public Teacher_CoursesManagementController(WebApplication2Context context)
        {
            _context = context;
        }

        // GET: Teacher_CoursesManagement
        public async Task<IActionResult> Index()
        {
            var webApplication2Context = _context.Teacher_CoursesManagement.Include(t => t.course).Include(t => t.teacher);
            return View(await webApplication2Context.ToListAsync());
        }

        // GET: Teacher_CoursesManagement/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher_CoursesManagement = await _context.Teacher_CoursesManagement
                .Include(t => t.course)
                .Include(t => t.teacher)
                .FirstOrDefaultAsync(m => m.id == id);
            if (teacher_CoursesManagement == null)
            {
                return NotFound();
            }

            return View(teacher_CoursesManagement);
        }

        // GET: Teacher_CoursesManagement/Create
        public IActionResult Create()
        {
            ViewData["course_id"] = new SelectList(_context.CourseManagement, "course_id", "course_name");
            ViewData["teacher_id"] = new SelectList(_context.TeacherManagement, "teacher_id", "email");
            return View();
        }

        // POST: Teacher_CoursesManagement/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,teacher_id,course_id")] Teacher_CoursesManagement teacher_CoursesManagement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teacher_CoursesManagement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["course_id"] = new SelectList(_context.CourseManagement, "course_id", "course_name", teacher_CoursesManagement.course_id);
            ViewData["teacher_id"] = new SelectList(_context.TeacherManagement, "teacher_id", "email", teacher_CoursesManagement.teacher_id);
            return View(teacher_CoursesManagement);
        }

        // GET: Teacher_CoursesManagement/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher_CoursesManagement = await _context.Teacher_CoursesManagement.FindAsync(id);
            if (teacher_CoursesManagement == null)
            {
                return NotFound();
            }
            ViewData["course_id"] = new SelectList(_context.CourseManagement, "course_id", "course_name", teacher_CoursesManagement.course_id);
            ViewData["teacher_id"] = new SelectList(_context.TeacherManagement, "teacher_id", "email", teacher_CoursesManagement.teacher_id);
            return View(teacher_CoursesManagement);
        }

        // POST: Teacher_CoursesManagement/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,teacher_id,course_id")] Teacher_CoursesManagement teacher_CoursesManagement)
        {
            if (id != teacher_CoursesManagement.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacher_CoursesManagement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Teacher_CoursesManagementExists(teacher_CoursesManagement.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["course_id"] = new SelectList(_context.CourseManagement, "course_id", "course_name", teacher_CoursesManagement.course_id);
            ViewData["teacher_id"] = new SelectList(_context.TeacherManagement, "teacher_id", "email", teacher_CoursesManagement.teacher_id);
            return View(teacher_CoursesManagement);
        }

        // GET: Teacher_CoursesManagement/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher_CoursesManagement = await _context.Teacher_CoursesManagement
                .Include(t => t.course)
                .Include(t => t.teacher)
                .FirstOrDefaultAsync(m => m.id == id);
            if (teacher_CoursesManagement == null)
            {
                return NotFound();
            }

            return View(teacher_CoursesManagement);
        }

        // POST: Teacher_CoursesManagement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teacher_CoursesManagement = await _context.Teacher_CoursesManagement.FindAsync(id);
            if (teacher_CoursesManagement != null)
            {
                _context.Teacher_CoursesManagement.Remove(teacher_CoursesManagement);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Teacher_CoursesManagementExists(int id)
        {
            return _context.Teacher_CoursesManagement.Any(e => e.id == id);
        }
    }
}
