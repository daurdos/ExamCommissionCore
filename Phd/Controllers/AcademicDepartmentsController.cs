using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Phd.Models;
using Phd.ViewModels;

namespace Phd.Controllers
{
    public class AcademicDepartmentsController : BaseController
    {
        public AcademicDepartmentsController(UserManager<User> userManager, SignInManager<User> signInManager, PhdContext context) : base(userManager, signInManager, context)
        {
        }

        // GET: AcademicDepartments
        public async Task<IActionResult> Index()
        {
            var phdContext = Context.AcademicDepartment.Include(a => a.Faculty);
            return View(await phdContext.ToListAsync());
        }

        // GET: AcademicDepartments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicDepartment = await Context.AcademicDepartment
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
            ViewData["FacultyId"] = new SelectList(Context.Faculty, "Id", "Id");
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
                Context.Add(academicDepartment);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FacultyId"] = new SelectList(Context.Faculty, "Id", "Id", academicDepartment.FacultyId);
            return View(academicDepartment);
        }

        // GET: AcademicDepartments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicDepartment = await Context.AcademicDepartment.FindAsync(id);
            if (academicDepartment == null)
            {
                return NotFound();
            }
            ViewData["FacultyId"] = new SelectList(Context.Faculty, "Id", "Id", academicDepartment.FacultyId);
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
                    Context.Update(academicDepartment);
                    await Context.SaveChangesAsync();
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
            ViewData["FacultyId"] = new SelectList(Context.Faculty, "Id", "Id", academicDepartment.FacultyId);
            return View(academicDepartment);
        }

        // GET: AcademicDepartments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var academicDepartment = await Context.AcademicDepartment
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
            var academicDepartment = await Context.AcademicDepartment.FindAsync(id);
            Context.AcademicDepartment.Remove(academicDepartment);
            await Context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcademicDepartmentExists(int id)
        {
            return Context.AcademicDepartment.Any(e => e.Id == id);
        }









    }
}
