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
    public class StudentManagementsController : Controller
    {
        private readonly WebApplication2Context _context;

        public StudentManagementsController(WebApplication2Context context)
        {
            _context = context;
        }

        // GET: StudentManagements
        public async Task<IActionResult> Index()
        {
            return View(await _context.StudentManagement.ToListAsync());
        }

        // GET: StudentManagements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentManagement = await _context.StudentManagement
                .FirstOrDefaultAsync(m => m.student_id == id);
            if (studentManagement == null)
            {
                return NotFound();
            }

            return View(studentManagement);
        }

        // GET: StudentManagements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentManagements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("student_id,name,email,password,phone")] StudentManagement studentManagement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentManagement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentManagement);
        }

        // GET: StudentManagements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentManagement = await _context.StudentManagement.FindAsync(id);
            if (studentManagement == null)
            {
                return NotFound();
            }
            return View(studentManagement);
        }

        // POST: StudentManagements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("student_id,name,email,password,phone")] StudentManagement studentManagement)
        {
            if (id != studentManagement.student_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentManagement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentManagementExists(studentManagement.student_id))
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
            return View(studentManagement);
        }

        // GET: StudentManagements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentManagement = await _context.StudentManagement
                .FirstOrDefaultAsync(m => m.student_id == id);
            if (studentManagement == null)
            {
                return NotFound();
            }

            return View(studentManagement);
        }

        // POST: StudentManagements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentManagement = await _context.StudentManagement.FindAsync(id);
            if (studentManagement != null)
            {
                _context.StudentManagement.Remove(studentManagement);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentManagementExists(int id)
        {
            return _context.StudentManagement.Any(e => e.student_id == id);
        }
    }
}
