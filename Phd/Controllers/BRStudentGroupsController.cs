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
    public class BRStudentGroupsController : BaseController
    {
        public BRStudentGroupsController(UserManager<User> userManager, SignInManager<User> signInManager, PhdContext context) : base(userManager, signInManager, context)
        {
        }

        // GET: BRStudentGroups
        public async Task<IActionResult> Index(int? commissioniId)
        {
            /*
            var allBRStudentGroups = Context.BRStudentGroup.ToList();
            var bRStudentGroupsByBRExamCommission = (from g in allBRStudentGroups
                                                     where g.BRExamCommissionId == commissioniId
                                                     select g).ToList();
            return View(bRStudentGroupsByBRExamCommission);
            */




            var phdContext = Context.BRStudentGroup.Include(b => b.BRExamCommission);
            return View(await phdContext.ToListAsync());
            
        }

        // GET: BRStudentGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bRStudentGroup = await Context.BRStudentGroup
                .Include(b => b.BRExamCommission)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bRStudentGroup == null)
            {
                return NotFound();
            }

            return View(bRStudentGroup);
        }

        // GET: BRStudentGroups/Create
        public IActionResult Create()
        {
            ViewData["BRExamCommissionId"] = new SelectList(Context.BRExamCommission, "Id", "Name");
            return View();
        }

        // POST: BRStudentGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,BRExamCommissionId")] BRStudentGroup bRStudentGroup)
        {
            if (ModelState.IsValid)
            {
                Context.Add(bRStudentGroup);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BRExamCommissionId"] = new SelectList(Context.BRExamCommission, "Id", "Id", bRStudentGroup.BRExamCommissionId);
            return View(bRStudentGroup);
        }

        // GET: BRStudentGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bRStudentGroup = await Context.BRStudentGroup.FindAsync(id);
            if (bRStudentGroup == null)
            {
                return NotFound();
            }
            ViewData["BRExamCommissionId"] = new SelectList(Context.BRExamCommission, "Id", "Id", bRStudentGroup.BRExamCommissionId);
            return View(bRStudentGroup);
        }

        // POST: BRStudentGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,BRExamCommissionId")] BRStudentGroup bRStudentGroup)
        {
            if (id != bRStudentGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Context.Update(bRStudentGroup);
                    await Context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BRStudentGroupExists(bRStudentGroup.Id))
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
            ViewData["BRExamCommissionId"] = new SelectList(Context.BRExamCommission, "Id", "Id", bRStudentGroup.BRExamCommissionId);
            return View(bRStudentGroup);
        }

        // GET: BRStudentGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bRStudentGroup = await Context.BRStudentGroup
                .Include(b => b.BRExamCommission)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bRStudentGroup == null)
            {
                return NotFound();
            }

            return View(bRStudentGroup);
        }

        // POST: BRStudentGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bRStudentGroup = await Context.BRStudentGroup.FindAsync(id);
            Context.BRStudentGroup.Remove(bRStudentGroup);
            await Context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BRStudentGroupExists(int id)
        {
            return Context.BRStudentGroup.Any(e => e.Id == id);
        }
    }
}
