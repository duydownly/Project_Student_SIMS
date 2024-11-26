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
    public class Student_CoursesManagementController : Controller
    {
        private readonly WebApplication2Context _context;

        public Student_CoursesManagementController(WebApplication2Context context)
        {
            _context = context;
        }

        // GET: Student_CoursesManagement
        public async Task<IActionResult> Index()
        {
            var webApplication2Context = _context.Student_CoursesManagement.Include(s => s.course).Include(s => s.student);
            return View(await webApplication2Context.ToListAsync());
        }

        // GET: Student_CoursesManagement/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student_CoursesManagement = await _context.Student_CoursesManagement
                .Include(s => s.course)
                .Include(s => s.student)
                .FirstOrDefaultAsync(m => m.id == id);
            if (student_CoursesManagement == null)
            {
                return NotFound();
            }

            return View(student_CoursesManagement);
        }

        // GET: Student_CoursesManagement/Create
        public IActionResult Create()
        {
            ViewData["course_id"] = new SelectList(_context.CourseManagement, "course_id", "course_name");
            ViewData["student_id"] = new SelectList(_context.StudentManagement, "student_id", "email");
            return View();
        }

        // POST: Student_CoursesManagement/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,student_id,course_id")] Student_CoursesManagement student_CoursesManagement)
        {
            if (ModelState.IsValid)
            {
                // Log thông tin dữ liệu trước khi thêm vào cơ sở dữ liệu
                Console.WriteLine("Creating StudentCourse with data:");
                Console.WriteLine($"Student ID: {student_CoursesManagement.student_id}");
                Console.WriteLine($"Course ID: {student_CoursesManagement.course_id}");

                _context.Add(student_CoursesManagement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["course_id"] = new SelectList(_context.CourseManagement, "course_id", "course_name", student_CoursesManagement.course_id);
            ViewData["student_id"] = new SelectList(_context.StudentManagement, "student_id", "email", student_CoursesManagement.student_id);
            return View(student_CoursesManagement);
        }

        // GET: Student_CoursesManagement/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student_CoursesManagement = await _context.Student_CoursesManagement.FindAsync(id);
            if (student_CoursesManagement == null)
            {
                return NotFound();
            }

            ViewData["course_id"] = new SelectList(_context.CourseManagement, "course_id", "course_name", student_CoursesManagement.course_id);
            ViewData["student_id"] = new SelectList(_context.StudentManagement, "student_id", "email", student_CoursesManagement.student_id);

            // Log thông tin dữ liệu trước khi sửa
            Console.WriteLine("Editing StudentCourse with data:");
            Console.WriteLine($"Student ID: {student_CoursesManagement.student_id}");
            Console.WriteLine($"Course ID: {student_CoursesManagement.course_id}");

            return View(student_CoursesManagement);
        }

        // POST: Student_CoursesManagement/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,student_id,course_id")] Student_CoursesManagement student_CoursesManagement)
        {
            if (id != student_CoursesManagement.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Log thông tin dữ liệu trước khi cập nhật
                    Console.WriteLine("Updating StudentCourse with data:");
                    Console.WriteLine($"Student ID: {student_CoursesManagement.student_id}");
                    Console.WriteLine($"Course ID: {student_CoursesManagement.course_id}");

                    _context.Update(student_CoursesManagement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Student_CoursesManagementExists(student_CoursesManagement.id))
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
            ViewData["course_id"] = new SelectList(_context.CourseManagement, "course_id", "course_name", student_CoursesManagement.course_id);
            ViewData["student_id"] = new SelectList(_context.StudentManagement, "student_id", "email", student_CoursesManagement.student_id);
            return View(student_CoursesManagement);
        }

        // GET: Student_CoursesManagement/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student_CoursesManagement = await _context.Student_CoursesManagement
                .Include(s => s.course)
                .Include(s => s.student)
                .FirstOrDefaultAsync(m => m.id == id);
            if (student_CoursesManagement == null)
            {
                return NotFound();
            }

            // Log thông tin dữ liệu trước khi xóa
            Console.WriteLine("Deleting StudentCourse with data:");
            Console.WriteLine($"Student ID: {student_CoursesManagement.student_id}");
            Console.WriteLine($"Course ID: {student_CoursesManagement.course_id}");

            return View(student_CoursesManagement);
        }

        // POST: Student_CoursesManagement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student_CoursesManagement = await _context.Student_CoursesManagement.FindAsync(id);
            if (student_CoursesManagement != null)
            {
                // Log thông tin dữ liệu trước khi xóa
                Console.WriteLine("Confirming delete of StudentCourse with data:");
                Console.WriteLine($"Student ID: {student_CoursesManagement.student_id}");
                Console.WriteLine($"Course ID: {student_CoursesManagement.course_id}");

                _context.Student_CoursesManagement.Remove(student_CoursesManagement);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Student_CoursesManagementExists(int id)
        {
            return _context.Student_CoursesManagement.Any(e => e.id == id);
        }
    }
}
