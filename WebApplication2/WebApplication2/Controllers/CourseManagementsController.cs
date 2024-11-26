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
    public class CourseManagementsController : Controller
    {
        private readonly WebApplication2Context _context;

        public CourseManagementsController(WebApplication2Context context)
        {
            _context = context;
        }

        // GET: CourseManagements
        public async Task<IActionResult> Index()
        {
            return View(await _context.CourseManagement.ToListAsync());
        }

        // GET: CourseManagements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseManagement = await _context.CourseManagement
                .FirstOrDefaultAsync(m => m.course_id == id);
            if (courseManagement == null)
            {
                return NotFound();
            }

            return View(courseManagement);
        }

        // GET: CourseManagements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CourseManagements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("course_id,course_name,description,course_fee")] CourseManagement courseManagement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseManagement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(courseManagement);
        }

        // GET: CourseManagements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseManagement = await _context.CourseManagement.FindAsync(id);
            if (courseManagement == null)
            {
                return NotFound();
            }
            return View(courseManagement);
        }

        // POST: CourseManagements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("course_id,course_name,description,course_fee")] CourseManagement courseManagement)
        {
            if (id != courseManagement.course_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseManagement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseManagementExists(courseManagement.course_id))
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
            return View(courseManagement);
        }

        // GET: CourseManagements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseManagement = await _context.CourseManagement
                .FirstOrDefaultAsync(m => m.course_id == id);
            if (courseManagement == null)
            {
                return NotFound();
            }

            return View(courseManagement);
        }

        // POST: CourseManagements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courseManagement = await _context.CourseManagement.FindAsync(id);
            if (courseManagement != null)
            {
                _context.CourseManagement.Remove(courseManagement);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseManagementExists(int id)
        {
            return _context.CourseManagement.Any(e => e.course_id == id);
        }
    }
}
