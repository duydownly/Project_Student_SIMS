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
    public class TeacherManagementsController : Controller
    {
        private readonly WebApplication2Context _context;

        public TeacherManagementsController(WebApplication2Context context)
        {
            _context = context;
        }

        // GET: TeacherManagements
        public async Task<IActionResult> Index()
        {
            return View(await _context.TeacherManagement.ToListAsync());
        }

        // GET: TeacherManagements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherManagement = await _context.TeacherManagement
                .FirstOrDefaultAsync(m => m.teacher_id == id);
            if (teacherManagement == null)
            {
                return NotFound();
            }

            return View(teacherManagement);
        }

        // GET: TeacherManagements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TeacherManagements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("teacher_id,email,password,name,phone")] TeacherManagement teacherManagement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teacherManagement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teacherManagement);
        }

        // GET: TeacherManagements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherManagement = await _context.TeacherManagement.FindAsync(id);
            if (teacherManagement == null)
            {
                return NotFound();
            }
            return View(teacherManagement);
        }

        // POST: TeacherManagements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("teacher_id,email,password,name,phone")] TeacherManagement teacherManagement)
        {
            if (id != teacherManagement.teacher_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacherManagement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherManagementExists(teacherManagement.teacher_id))
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
            return View(teacherManagement);
        }

        // GET: TeacherManagements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherManagement = await _context.TeacherManagement
                .FirstOrDefaultAsync(m => m.teacher_id == id);
            if (teacherManagement == null)
            {
                return NotFound();
            }

            return View(teacherManagement);
        }

        // POST: TeacherManagements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teacherManagement = await _context.TeacherManagement.FindAsync(id);
            if (teacherManagement != null)
            {
                _context.TeacherManagement.Remove(teacherManagement);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherManagementExists(int id)
        {
            return _context.TeacherManagement.Any(e => e.teacher_id == id);
        }
    }
}
