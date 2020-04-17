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
    public class BRStudentDocsController : Controller
    {
        private readonly PhdContext _context;

        public BRStudentDocsController(PhdContext context)
        {
            _context = context;
        }

        // GET: BRStudentDocs
        public async Task<IActionResult> Index()
        {
            var phdContext = _context.BRStudentDoc.Include(b => b.BRStudent).Include(b => b.StudentDocType);
            return View(await phdContext.ToListAsync());
        }

        // GET: BRStudentDocs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bRStudentDoc = await _context.BRStudentDoc
                .Include(b => b.BRStudent)
                .Include(b => b.StudentDocType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bRStudentDoc == null)
            {
                return NotFound();
            }

            return View(bRStudentDoc);
        }

        // GET: BRStudentDocs/Create
        public IActionResult Create()
        {
            ViewData["BRStudentId"] = new SelectList(_context.BRStudent, "Id", "Name");
            ViewData["StudentDocTypeId"] = new SelectList(_context.Set<StudentDocType>(), "Id", "Id");
            return View();
        }

        // POST: BRStudentDocs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,BRStudentId,StudentDocTypeId")] BRStudentDoc bRStudentDoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bRStudentDoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BRStudentId"] = new SelectList(_context.BRStudent, "Id", "Id", bRStudentDoc.BRStudentId);
            ViewData["StudentDocTypeId"] = new SelectList(_context.Set<StudentDocType>(), "Id", "Id", bRStudentDoc.StudentDocTypeId);
            return View(bRStudentDoc);
        }

        // GET: BRStudentDocs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bRStudentDoc = await _context.BRStudentDoc.FindAsync(id);
            if (bRStudentDoc == null)
            {
                return NotFound();
            }
            ViewData["BRStudentId"] = new SelectList(_context.BRStudent, "Id", "Id", bRStudentDoc.BRStudentId);
            ViewData["StudentDocTypeId"] = new SelectList(_context.Set<StudentDocType>(), "Id", "Id", bRStudentDoc.StudentDocTypeId);
            return View(bRStudentDoc);
        }

        // POST: BRStudentDocs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,BRStudentId,StudentDocTypeId")] BRStudentDoc bRStudentDoc)
        {
            if (id != bRStudentDoc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bRStudentDoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BRStudentDocExists(bRStudentDoc.Id))
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
            ViewData["BRStudentId"] = new SelectList(_context.BRStudent, "Id", "Id", bRStudentDoc.BRStudentId);
            ViewData["StudentDocTypeId"] = new SelectList(_context.Set<StudentDocType>(), "Id", "Id", bRStudentDoc.StudentDocTypeId);
            return View(bRStudentDoc);
        }

        // GET: BRStudentDocs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bRStudentDoc = await _context.BRStudentDoc
                .Include(b => b.BRStudent)
                .Include(b => b.StudentDocType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bRStudentDoc == null)
            {
                return NotFound();
            }

            return View(bRStudentDoc);
        }

        // POST: BRStudentDocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bRStudentDoc = await _context.BRStudentDoc.FindAsync(id);
            _context.BRStudentDoc.Remove(bRStudentDoc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BRStudentDocExists(int id)
        {
            return _context.BRStudentDoc.Any(e => e.Id == id);
        }
    }
}
