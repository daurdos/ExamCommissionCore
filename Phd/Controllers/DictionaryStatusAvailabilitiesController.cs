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
    public class DictionaryStatusAvailabilitiesController : Controller
    {
        private readonly PhdContext _context;

        public DictionaryStatusAvailabilitiesController(PhdContext context)
        {
            _context = context;
        }

        // GET: DictionaryStatusAvailabilities
        public async Task<IActionResult> Index()
        {
            return View(await _context.DictionaryStatusAvailability.ToListAsync());
        }

        // GET: DictionaryStatusAvailabilities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictionaryStatusAvailability = await _context.DictionaryStatusAvailability
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictionaryStatusAvailability == null)
            {
                return NotFound();
            }

            return View(dictionaryStatusAvailability);
        }

        // GET: DictionaryStatusAvailabilities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DictionaryStatusAvailabilities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ValueRus,ValueKaz,ValueEng")] DictionaryStatusAvailability dictionaryStatusAvailability)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dictionaryStatusAvailability);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dictionaryStatusAvailability);
        }

        // GET: DictionaryStatusAvailabilities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictionaryStatusAvailability = await _context.DictionaryStatusAvailability.FindAsync(id);
            if (dictionaryStatusAvailability == null)
            {
                return NotFound();
            }
            return View(dictionaryStatusAvailability);
        }

        // POST: DictionaryStatusAvailabilities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ValueRus,ValueKaz,ValueEng")] DictionaryStatusAvailability dictionaryStatusAvailability)
        {
            if (id != dictionaryStatusAvailability.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dictionaryStatusAvailability);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DictionaryStatusAvailabilityExists(dictionaryStatusAvailability.Id))
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
            return View(dictionaryStatusAvailability);
        }

        // GET: DictionaryStatusAvailabilities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dictionaryStatusAvailability = await _context.DictionaryStatusAvailability
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dictionaryStatusAvailability == null)
            {
                return NotFound();
            }

            return View(dictionaryStatusAvailability);
        }

        // POST: DictionaryStatusAvailabilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dictionaryStatusAvailability = await _context.DictionaryStatusAvailability.FindAsync(id);
            _context.DictionaryStatusAvailability.Remove(dictionaryStatusAvailability);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DictionaryStatusAvailabilityExists(int id)
        {
            return _context.DictionaryStatusAvailability.Any(e => e.Id == id);
        }
    }
}
