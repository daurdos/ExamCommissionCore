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
    public class BDirectionsController : Controller
    {
        private readonly PhdContext _context;

        public BDirectionsController(PhdContext context)
        {
            _context = context;
        }

        // GET: BDirections
        public async Task<IActionResult> Index()
        {
            var phdContext = _context.BDirection.Include(b => b.AcademicDepartment);
            return View(await phdContext.ToListAsync());
        }

        // GET: BDirections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bDirection = await _context.BDirection
                .Include(b => b.AcademicDepartment)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bDirection == null)
            {
                return NotFound();
            }

            return View(bDirection);
        }

        // GET: BDirections/Create
        public IActionResult Create()
        {
            ViewData["AcademicDepartmentId"] = new SelectList(_context.AcademicDepartment, "Id", "Name");
            return View();
        }

        // POST: BDirections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cypher,NameRus,NameKaz,NameEng,AcademicDepartmentId")] BDirection bDirection)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bDirection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AcademicDepartmentId"] = new SelectList(_context.AcademicDepartment, "Id", "Id", bDirection.AcademicDepartmentId);
            return View(bDirection);
        }

        // GET: BDirections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bDirection = await _context.BDirection.FindAsync(id);
            if (bDirection == null)
            {
                return NotFound();
            }
            ViewData["AcademicDepartmentId"] = new SelectList(_context.AcademicDepartment, "Id", "Id", bDirection.AcademicDepartmentId);
            return View(bDirection);
        }

        // POST: BDirections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cypher,NameRus,NameKaz,NameEng,AcademicDepartmentId")] BDirection bDirection)
        {
            if (id != bDirection.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bDirection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BDirectionExists(bDirection.Id))
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
            ViewData["AcademicDepartmentId"] = new SelectList(_context.AcademicDepartment, "Id", "Id", bDirection.AcademicDepartmentId);
            return View(bDirection);
        }

        // GET: BDirections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bDirection = await _context.BDirection
                .Include(b => b.AcademicDepartment)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bDirection == null)
            {
                return NotFound();
            }

            return View(bDirection);
        }

        // POST: BDirections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bDirection = await _context.BDirection.FindAsync(id);
            _context.BDirection.Remove(bDirection);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BDirectionExists(int id)
        {
            return _context.BDirection.Any(e => e.Id == id);
        }
    }
}
