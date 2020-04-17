using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Phd.Models;

namespace Phd.Controllers
{
    public class BRStudentsController : BaseController
    {
        public BRStudentsController(UserManager<User> userManager, SignInManager<User> signInManager, PhdContext context) : base(userManager, signInManager, context)
        {
        }

        // GET: BRStudents
        public async Task<IActionResult> Index(int? id)
        {
            var allStudents = Context.BRStudent.ToList();
            var studentsByGroup = (from student in allStudents
                                   where student.BRStudentGroupId == id
                                   select student).ToList();
            return View(studentsByGroup);
            /*
            var phdContext = Context.BRStudent.Include(b => b.BRStudentGroup);
            return View(await Context.BRStudent.ToListAsync());
            */
        }

        // GET: BRStudents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bRStudent = await Context.BRStudent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bRStudent == null)
            {
                return NotFound();
            }

            return View(bRStudent);
        }

        // GET: BRStudents/Create
        public IActionResult Create()
        {
            ViewData["BRStudentGroupId"] = new SelectList(Context.BRStudentGroup, "Id", "Name");
            return View();
        }

        // POST: BRStudents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,BRStudentGroupId")] BRStudent bRStudent)
        {
            if (ModelState.IsValid)
            {
                Context.Add(bRStudent);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bRStudent);
        }

        // GET: BRStudents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bRStudent = await Context.BRStudent.FindAsync(id);
            if (bRStudent == null)
            {
                return NotFound();
            }
            return View(bRStudent);
        }

        // POST: BRStudents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,BRStudentGroupId")] BRStudent bRStudent)
        {
            if (id != bRStudent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Context.Update(bRStudent);
                    await Context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BRStudentExists(bRStudent.Id))
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
            return View(bRStudent);
        }

        // GET: BRStudents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bRStudent = await Context.BRStudent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bRStudent == null)
            {
                return NotFound();
            }

            return View(bRStudent);
        }

        // POST: BRStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bRStudent = await Context.BRStudent.FindAsync(id);
            Context.BRStudent.Remove(bRStudent);
            await Context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BRStudentExists(int id)
        {
            return Context.BRStudent.Any(e => e.Id == id);
        }
    }
}
