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
    public class DictionaryAcademicDegreesController : Controller
    {
        private readonly PhdContext _context;

        public DictionaryAcademicDegreesController(PhdContext context)
        {
            _context = context;
        }

        // GET: DictionaryAcademicDegrees
        public async Task<IActionResult> Index()
        {
            return View(await _context.DictionaryAcademicDegree.ToListAsync());
        }

        // GET: DictionaryAcademicDegrees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictionaryAcademicDegree = await _context.DictionaryAcademicDegree
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictionaryAcademicDegree == null)
            {
                return NotFound();
            }

            return View(dictionaryAcademicDegree);
        }

        // GET: DictionaryAcademicDegrees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DictionaryAcademicDegrees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ValueRus,ValueKaz,ValueEng")] DictionaryAcademicDegree dictionaryAcademicDegree)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dictionaryAcademicDegree);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dictionaryAcademicDegree);
        }

        // GET: DictionaryAcademicDegrees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictionaryAcademicDegree = await _context.DictionaryAcademicDegree.FindAsync(id);
            if (dictionaryAcademicDegree == null)
            {
                return NotFound();
            }
            return View(dictionaryAcademicDegree);
        }

        // POST: DictionaryAcademicDegrees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ValueRus,ValueKaz,ValueEng")] DictionaryAcademicDegree dictionaryAcademicDegree)
        {
            if (id != dictionaryAcademicDegree.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dictionaryAcademicDegree);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DictionaryAcademicDegreeExists(dictionaryAcademicDegree.Id))
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
            return View(dictionaryAcademicDegree);
        }

        // GET: DictionaryAcademicDegrees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictionaryAcademicDegree = await _context.DictionaryAcademicDegree
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictionaryAcademicDegree == null)
            {
                return NotFound();
            }

            return View(dictionaryAcademicDegree);
        }

        // POST: DictionaryAcademicDegrees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dictionaryAcademicDegree = await _context.DictionaryAcademicDegree.FindAsync(id);
            _context.DictionaryAcademicDegree.Remove(dictionaryAcademicDegree);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DictionaryAcademicDegreeExists(int id)
        {
            return _context.DictionaryAcademicDegree.Any(e => e.Id == id);
        }
    }
}
