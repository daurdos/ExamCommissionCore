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
    public class BMajorsController : BaseController
    {
        public BMajorsController(UserManager<User> userManager, SignInManager<User> signInManager, PhdContext context) : base(userManager, signInManager, context)
        {
        }

        // GET: BMajors
        public async Task<IActionResult> Index()
        {
            var phdContext = Context.BMajor.Include(b => b.AcademicDepartment).Include(b=>b.BRExamCommission);
            ViewBag.UserId = UserManager.GetUserId(HttpContext.User);

            if (IsAdmin())
            {
                return View(await phdContext.ToListAsync());
            }
            else
            {
                return View(await phdContext.Where(x=>x.AcademicDepartmentId == GetUser().AcademicDepartmentId).ToListAsync());
            }
            

        }

        // GET: BMajors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bMajor = await Context.BMajor
                .Include(b => b.AcademicDepartment)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bMajor == null)
            {
                return NotFound();
            }

            return View(bMajor);
        }

        // GET: BMajors/Create
        public IActionResult Create()
        {
            ViewData["AcademicDepartmentId"] = new SelectList(Context.AcademicDepartment, "Id", "Name");
            return View();
        }

        // POST: BMajors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cypher,NameRus,NameKaz,NameEng,AcademicDepartmentId")] BMajor bMajor)
        {
            if (ModelState.IsValid)
            {
                Context.Add(bMajor);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AcademicDepartmentId"] = new SelectList(Context.AcademicDepartment, "Id", "Id", bMajor.AcademicDepartmentId);
            return View(bMajor);
        }

        // GET: BMajors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bMajor = await Context.BMajor.FindAsync(id);
            if (bMajor == null)
            {
                return NotFound();
            }
            ViewData["AcademicDepartmentId"] = new SelectList(Context.AcademicDepartment, "Id", "Id", bMajor.AcademicDepartmentId);
            return View(bMajor);
        }

        // POST: BMajors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cypher,NameRus,NameKaz,NameEng,AcademicDepartmentId")] BMajor bMajor)
        {
            if (id != bMajor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Context.Update(bMajor);
                    await Context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BMajorExists(bMajor.Id))
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
            ViewData["AcademicDepartmentId"] = new SelectList(Context.AcademicDepartment, "Id", "Id", bMajor.AcademicDepartmentId);
            return View(bMajor);
        }

        // GET: BMajors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bMajor = await Context.BMajor
                .Include(b => b.AcademicDepartment)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bMajor == null)
            {
                return NotFound();
            }

            return View(bMajor);
        }

        // POST: BMajors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bMajor = await Context.BMajor.FindAsync(id);
            Context.BMajor.Remove(bMajor);
            await Context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BMajorExists(int id)
        {
            return Context.BMajor.Any(e => e.Id == id);
        }









        public IActionResult CreateBRExamCommission(int id)
        {
            ViewBag.Id = id;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBRExamCommission([Bind("Name,BMajorId")] BRExamCommission bRExamCommission)
        {
            if (ModelState.IsValid)
            {
                Context.Add(bRExamCommission);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(Success));
            }
            return View(bRExamCommission);
        }


        public IActionResult GetBRExamCommission(int id)
        {

            var allBRExamCommissions = Context.BRExamCommission.ToList();
            var bRExamCommissionsByBMajor = (from c in allBRExamCommissions
                                             where c.BMajorId == id
                                             select c).ToList();
            return View(bRExamCommissionsByBMajor);
        }


        public IActionResult CreateBRStudentGroups(int id)
        {
            ViewBag.Id = id;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBRStudentGroups([Bind("Name,BRExamCommissionId")] BRStudentGroup bRStudentGroup)
        {
            if (ModelState.IsValid)
            {
                Context.Add(bRStudentGroup);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(Success));
            }
            return View(bRStudentGroup);
        }

        public IActionResult GetBRStudentGroups(int id)
        {

            var allBRStudentGroups = Context.BRStudentGroup.ToList();
            var bRStudentGroupsByBRExamCommission = (from g in allBRStudentGroups
                                             where g.BRExamCommissionId == id
                                             select g).ToList();
            return View(bRStudentGroupsByBRExamCommission);
        }


        public IActionResult CreateBRStudent(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBRStudent([Bind("Name,BRStudentGroupId")] BRStudent bRStudent)
        {
            if (ModelState.IsValid)
            {
                Context.Add(bRStudent);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(Success));
            }
            return View(bRStudent);
        }

        public IActionResult GetBRStudents(int id)
        {

            ViewBag.UserId = UserManager.GetUserId(HttpContext.User);
            var allBRStudents = Context.BRStudent.ToList();
            var bRStudentsByBRStudentGroup = (from g in allBRStudents
                                                     where g.BRStudentGroupId == id
                                                     select g).ToList();
            return View(bRStudentsByBRStudentGroup);
        }

        public IActionResult CreateBRStudentGrade(int studentId, string userId)
        {
            var bRStudentGrades = Context.BRStudentGrade.ToList();
            var condition = bRStudentGrades != null && bRStudentGrades.Any(x => x.UserId ==  userId && x.BRStudentId == studentId);
           if (!condition)
           {
                ViewBag.StudentId = studentId;
                ViewBag.UserId = UserManager.GetUserId(HttpContext.User);
            }
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBRStudentGrade([Bind("Value,BRStudentId,UserId")] BRStudentGrade bRStudentGrade)
        {


            if (ModelState.IsValid)
            {

                Context.Update(bRStudentGrade);
                await Context.SaveChangesAsync();


                return RedirectToAction(nameof(Success));
            }
            return View(bRStudentGrade);
        }

        [HttpGet]
        public async Task<IActionResult> GetBRStudentGrade(int studentId)
        {

            var student = await Context.BRStudent.Include(x => x.BRStudentGrade).FirstOrDefaultAsync(x => x.Id == studentId);
            return View(new StudentGradeViewModel
            {
                StudentName = student.Name,
                AverageGrade = student.BRStudentGrade.Average(x=>x.Value)
            });
        }



        public async Task<IActionResult> Success()
        {
            return View();
        }


    }
}
