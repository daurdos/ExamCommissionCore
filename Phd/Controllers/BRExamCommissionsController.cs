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
    public class BRExamCommissionsController : BaseController
    {
        public BRExamCommissionsController(UserManager<User> userManager, SignInManager<User> signInManager, PhdContext context) : base(userManager, signInManager, context)
        {
        }

        // GET: BRExamCommissions
        public async Task<IActionResult> Index(int? majorId)
        {

            var phdContext = Context.BRExamCommission.Include(b => b.BMajor).Include(b => b.BRStudentGroup);
            ViewBag.UserId = UserManager.GetUserId(HttpContext.User);
            if (IsAdmin())
            {
                return View(await phdContext.ToListAsync());
            }
            else
            {
                return View(await phdContext.Where(x => x.BMajorId == GetUser().BMajorId).ToListAsync());
            }







        }

        // GET: BRExamCommissions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bRExamCommission = await Context.BRExamCommission
                .Include(b => b.BMajor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bRExamCommission == null)
            {
                return NotFound();
            }

            return View(bRExamCommission);
        }

        // GET: BRExamCommissions/Create
        public IActionResult Create()
        {
            ViewData["BMajorId"] = new SelectList(Context.BMajor, "Id", "Cypher");
            return View();
        }

        // POST: BRExamCommissions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,BMajorId")] BRExamCommission bRExamCommission)
        {
            if (ModelState.IsValid)
            {
                Context.Add(bRExamCommission);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BMajorId"] = new SelectList(Context.BMajor, "Id", "Id", bRExamCommission.BMajorId);
            return View(bRExamCommission);
        }

        // GET: BRExamCommissions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bRExamCommission = await Context.BRExamCommission.FindAsync(id);
            if (bRExamCommission == null)
            {
                return NotFound();
            }
            ViewData["BMajorId"] = new SelectList(Context.BMajor, "Id", "Id", bRExamCommission.BMajorId);
            return View(bRExamCommission);
        }

        // POST: BRExamCommissions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,BMajorId")] BRExamCommission bRExamCommission)
        {
            if (id != bRExamCommission.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Context.Update(bRExamCommission);
                    await Context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BRExamCommissionExists(bRExamCommission.Id))
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
            ViewData["BMajorId"] = new SelectList(Context.BMajor, "Id", "Id", bRExamCommission.BMajorId);
            return View(bRExamCommission);
        }

        // GET: BRExamCommissions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bRExamCommission = await Context.BRExamCommission
                .Include(b => b.BMajor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bRExamCommission == null)
            {
                return NotFound();
            }

            return View(bRExamCommission);
        }

        // POST: BRExamCommissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bRExamCommission = await Context.BRExamCommission.FindAsync(id);
            Context.BRExamCommission.Remove(bRExamCommission);
            await Context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BRExamCommissionExists(int id)
        {
            return Context.BRExamCommission.Any(e => e.Id == id);
        }
    }
}
