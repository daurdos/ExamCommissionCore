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
    public class StudentDocTypesController : Controller
    {
        private readonly PhdContext _context;

        public StudentDocTypesController(PhdContext context)
        {
            _context = context;
        }

        // GET: StudentDocTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.StudentDocType.ToListAsync());
        }

        // GET: StudentDocTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentDocType = await _context.StudentDocType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentDocType == null)
            {
                return NotFound();
            }

            return View(studentDocType);
        }

        // GET: StudentDocTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentDocTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] StudentDocType studentDocType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentDocType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentDocType);
        }

        // GET: StudentDocTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentDocType = await _context.StudentDocType.FindAsync(id);
            if (studentDocType == null)
            {
                return NotFound();
            }
            return View(studentDocType);
        }

        // POST: StudentDocTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] StudentDocType studentDocType)
        {
            if (id != studentDocType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentDocType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentDocTypeExists(studentDocType.Id))
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
            return View(studentDocType);
        }

        // GET: StudentDocTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentDocType = await _context.StudentDocType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentDocType == null)
            {
                return NotFound();
            }

            return View(studentDocType);
        }

        // POST: StudentDocTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentDocType = await _context.StudentDocType.FindAsync(id);
            _context.StudentDocType.Remove(studentDocType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentDocTypeExists(int id)
        {
            return _context.StudentDocType.Any(e => e.Id == id);
        }
    }
}
