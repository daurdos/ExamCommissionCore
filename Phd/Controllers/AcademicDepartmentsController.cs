using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Phd.Models;

namespace Phd.Controllers
{
    public class AcademicDepartmentsController : Controller
    {
        private readonly PhdContext _context;

        public AcademicDepartmentsController(PhdContext context)
        {
            _context = context;
        }

        // GET: AcademicDepartments
        public async Task<IActionResult> Index()
        {
            var phdContext = _context.AcademicDepartment.Include(a => a.Faculty);
            return View(await phdContext.ToListAsync());
        }

        // GET: AcademicDepartments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicDepartment = await _context.AcademicDepartment
                .Include(a => a.Faculty)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (academicDepartment == null)
            {
                return NotFound();
            }

            return View(academicDepartment);
        }

        // GET: AcademicDepartments/Create
        public IActionResult Create()
        {
            ViewData["FacultyId"] = new SelectList(_context.Faculty, "Id", "Name");
            return View();
        }

        // POST: AcademicDepartments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,FacultyId")] AcademicDepartment academicDepartment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(academicDepartment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FacultyId"] = new SelectList(_context.Faculty, "Id", "Id", academicDepartment.FacultyId);
            return View(academicDepartment);
        }

        // GET: AcademicDepartments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicDepartment = await _context.AcademicDepartment.FindAsync(id);
            if (academicDepartment == null)
            {
                return NotFound();
            }
            ViewData["FacultyId"] = new SelectList(_context.Faculty, "Id", "Id", academicDepartment.FacultyId);
            return View(academicDepartment);
        }

        // POST: AcademicDepartments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,FacultyId")] AcademicDepartment academicDepartment)
        {
            if (id != academicDepartment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(academicDepartment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcademicDepartmentExists(academicDepartment.Id))
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
            ViewData["FacultyId"] = new SelectList(_context.Faculty, "Id", "Id", academicDepartment.FacultyId);
            return View(academicDepartment);
        }

        // GET: AcademicDepartments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicDepartment = await _context.AcademicDepartment
                .Include(a => a.Faculty)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (academicDepartment == null)
            {
                return NotFound();
            }

            return View(academicDepartment);
        }

        // POST: AcademicDepartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var academicDepartment = await _context.AcademicDepartment.FindAsync(id);
            _context.AcademicDepartment.Remove(academicDepartment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcademicDepartmentExists(int id)
        {
            return _context.AcademicDepartment.Any(e => e.Id == id);
        }
    }
}
