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
    public class BRStudentGradesController : Controller
    {
        private readonly PhdContext _context;

        public BRStudentGradesController(PhdContext context)
        {
            _context = context;
        }

        // GET: BRStudentGrades
        public async Task<IActionResult> Index()
        {
            var phdContext = _context.BRStudentGrade.Include(b => b.BRStudent).Include(b => b.User);
            return View(await phdContext.ToListAsync());
        }

        // GET: BRStudentGrades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bRStudentGrade = await _context.BRStudentGrade
                .Include(b => b.BRStudent)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bRStudentGrade == null)
            {
                return NotFound();
            }

            return View(bRStudentGrade);
        }

        // GET: BRStudentGrades/Create
        public IActionResult Create()
        {
            ViewData["BRStudentId"] = new SelectList(_context.BRStudent, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: BRStudentGrades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Value,BRStudentId,UserId")] BRStudentGrade bRStudentGrade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bRStudentGrade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BRStudentId"] = new SelectList(_context.BRStudent, "Id", "Id", bRStudentGrade.BRStudentId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", bRStudentGrade.UserId);
            return View(bRStudentGrade);
        }

        // GET: BRStudentGrades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bRStudentGrade = await _context.BRStudentGrade.FindAsync(id);
            if (bRStudentGrade == null)
            {
                return NotFound();
            }
            ViewData["BRStudentId"] = new SelectList(_context.BRStudent, "Id", "Id", bRStudentGrade.BRStudentId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", bRStudentGrade.UserId);
            return View(bRStudentGrade);
        }

        // POST: BRStudentGrades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Value,BRStudentId,UserId")] BRStudentGrade bRStudentGrade)
        {
            if (id != bRStudentGrade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bRStudentGrade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BRStudentGradeExists(bRStudentGrade.Id))
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
            ViewData["BRStudentId"] = new SelectList(_context.BRStudent, "Id", "Id", bRStudentGrade.BRStudentId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", bRStudentGrade.UserId);
            return View(bRStudentGrade);
        }

        // GET: BRStudentGrades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bRStudentGrade = await _context.BRStudentGrade
                .Include(b => b.BRStudent)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bRStudentGrade == null)
            {
                return NotFound();
            }

            return View(bRStudentGrade);
        }

        // POST: BRStudentGrades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bRStudentGrade = await _context.BRStudentGrade.FindAsync(id);
            _context.BRStudentGrade.Remove(bRStudentGrade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BRStudentGradeExists(int id)
        {
            return _context.BRStudentGrade.Any(e => e.Id == id);
        }
    }
}
