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
    public class DictionaryStatusConclusionsController : Controller
    {
        private readonly PhdContext _context;

        public DictionaryStatusConclusionsController(PhdContext context)
        {
            _context = context;
        }

        // GET: DictionaryStatusConclusions
        public async Task<IActionResult> Index()
        {
            return View(await _context.DictionaryStatusConclusion.ToListAsync());
        }

        // GET: DictionaryStatusConclusions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictionaryStatusConclusion = await _context.DictionaryStatusConclusion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictionaryStatusConclusion == null)
            {
                return NotFound();
            }

            return View(dictionaryStatusConclusion);
        }

        // GET: DictionaryStatusConclusions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DictionaryStatusConclusions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ValueRus,ValueKaz,ValueEng")] DictionaryStatusConclusion dictionaryStatusConclusion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dictionaryStatusConclusion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dictionaryStatusConclusion);
        }

        // GET: DictionaryStatusConclusions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictionaryStatusConclusion = await _context.DictionaryStatusConclusion.FindAsync(id);
            if (dictionaryStatusConclusion == null)
            {
                return NotFound();
            }
            return View(dictionaryStatusConclusion);
        }

        // POST: DictionaryStatusConclusions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ValueRus,ValueKaz,ValueEng")] DictionaryStatusConclusion dictionaryStatusConclusion)
        {
            if (id != dictionaryStatusConclusion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dictionaryStatusConclusion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DictionaryStatusConclusionExists(dictionaryStatusConclusion.Id))
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
            return View(dictionaryStatusConclusion);
        }

        // GET: DictionaryStatusConclusions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictionaryStatusConclusion = await _context.DictionaryStatusConclusion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictionaryStatusConclusion == null)
            {
                return NotFound();
            }

            return View(dictionaryStatusConclusion);
        }

        // POST: DictionaryStatusConclusions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dictionaryStatusConclusion = await _context.DictionaryStatusConclusion.FindAsync(id);
            _context.DictionaryStatusConclusion.Remove(dictionaryStatusConclusion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DictionaryStatusConclusionExists(int id)
        {
            return _context.DictionaryStatusConclusion.Any(e => e.Id == id);
        }
    }
}
