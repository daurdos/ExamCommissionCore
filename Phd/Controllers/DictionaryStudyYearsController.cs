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
    public class DictionaryStudyYearsController : Controller
    {
        private readonly PhdContext _context;

        public DictionaryStudyYearsController(PhdContext context)
        {
            _context = context;
        }

        // GET: DictionaryStudyYears
        public async Task<IActionResult> Index()
        {
            return View(await _context.DictionaryStudyYear.ToListAsync());
        }

        // GET: DictionaryStudyYears/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictionaryStudyYear = await _context.DictionaryStudyYear
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictionaryStudyYear == null)
            {
                return NotFound();
            }

            return View(dictionaryStudyYear);
        }

        // GET: DictionaryStudyYears/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DictionaryStudyYears/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Value")] DictionaryStudyYear dictionaryStudyYear)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dictionaryStudyYear);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dictionaryStudyYear);
        }

        // GET: DictionaryStudyYears/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictionaryStudyYear = await _context.DictionaryStudyYear.FindAsync(id);
            if (dictionaryStudyYear == null)
            {
                return NotFound();
            }
            return View(dictionaryStudyYear);
        }

        // POST: DictionaryStudyYears/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Value")] DictionaryStudyYear dictionaryStudyYear)
        {
            if (id != dictionaryStudyYear.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dictionaryStudyYear);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DictionaryStudyYearExists(dictionaryStudyYear.Id))
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
            return View(dictionaryStudyYear);
        }

        // GET: DictionaryStudyYears/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictionaryStudyYear = await _context.DictionaryStudyYear
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictionaryStudyYear == null)
            {
                return NotFound();
            }

            return View(dictionaryStudyYear);
        }

        // POST: DictionaryStudyYears/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dictionaryStudyYear = await _context.DictionaryStudyYear.FindAsync(id);
            _context.DictionaryStudyYear.Remove(dictionaryStudyYear);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DictionaryStudyYearExists(int id)
        {
            return _context.DictionaryStudyYear.Any(e => e.Id == id);
        }
    }
}
