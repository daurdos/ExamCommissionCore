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
            var phdContext = Context.BMajor.Include(b => b.AcademicDepartment);
            ViewBag.UserId = UserManager.GetUserId(HttpContext.User);

            if (IsAdmin())
            {
                return View(await phdContext.ToListAsync());
            }
            else
            {
                return View(await phdContext.Where(x => x.Id == GetUser().BMajorId).ToListAsync());
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

        /// ******************************************************************************************************
        /// ******************************************************************************************************
        /// ******************************************************************************************************
        /// ******************************************************************************************************
        /// ******************************************************************************************************
        /// ******************************************************************************************************
        /// ******************************************************************************************************
        /// ******************************************************************************************************
        /// Начало моей логики


        // начало создания потоков студентов на рус яз
        public async Task<IActionResult> CreateStudentGroupRusAsync(int id)
        {
            var bMajor = await Context.BMajor.Where(x => x.Id == id).FirstOrDefaultAsync();

            ViewBag.Id = id;
            ViewBag.Name = bMajor.Cypher;
            ViewBag.Type = "Rus";

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStudentGroupRusAsync([Bind("Name,Type,BMajorId")] BRStudentGroup bRStudentGroup)
        {
            //string UserId = UserManager.GetUserId(HttpContext.User);
            string userName = UserManager.GetUserName(HttpContext.User);
            var phdContext = Context.BRStudentGroup.Include(b => b.BMajor);
            if (ModelState.IsValid)
            {
                // переделываю метод создания 
                Context.Add(bRStudentGroup);
                await Context.SaveChangesAsync();

                ////// DAUREN: ADDING USER LOGS
                UserActivity userActivity = new UserActivity()
                {
                    UserName = userName,
                    TimeStamp = DateTime.Now,
                    Activity = "Создание потока студентов на рус.яз.",
                    Description = $"Поток студентов на рус. яз. № {bRStudentGroup.Id} создан {userName} в {DateTime.Now}"
                };
                Context.Add(userActivity);
                await Context.SaveChangesAsync();
                ///***
                return RedirectToAction(nameof(Index));
            }
          //  ViewData["BMajorId"] = new SelectList(Context.BMajor, "Id", "Id", bRStudentGroup.BMajorId);
            return View(bRStudentGroup);
        }

        // *** конец создания потоков на рус яз


        // начало получения потоков рус студентов 
        public async Task<IActionResult> GetStudentGroupRusAsync(int id)
        {
            ViewBag.UserId = UserManager.GetUserId(HttpContext.User);
            var studentGroups = await Context.BRStudentGroup
                                   .Where(m => m.BMajorId == id)
                                   .Where(m=>m.Type == "Rus")
                                   .ToListAsync();
            return View(studentGroups);
        }

        //*** конец получения потоков на рус яз


        // начало создания потоков студентов на каз яз
        public async Task<IActionResult> CreateStudentGroupKazAsync(int id)
        {
            var bMajor = await Context.BMajor.Where(x => x.Id == id).FirstOrDefaultAsync();

            ViewBag.Id = id;
            ViewBag.Name = bMajor.Cypher;
            ViewBag.Type = "Kaz";

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStudentGroupKazAsync([Bind("Name,Type,BMajorId")] BRStudentGroup bRStudentGroup)
        {
            //string UserId = UserManager.GetUserId(HttpContext.User);
            string userName = UserManager.GetUserName(HttpContext.User);
            var phdContext = Context.BRStudentGroup.Include(b => b.BMajor);
            if (ModelState.IsValid)
            {
                // переделываю метод создания 
                Context.Add(bRStudentGroup);
                await Context.SaveChangesAsync();

                ////// DAUREN: ADDING USER LOGS
                UserActivity userActivity = new UserActivity()
                {
                    UserName = userName,
                    TimeStamp = DateTime.Now,
                    Activity = "Создание потока студентов на каз.яз.",
                    Description = $"Поток студентов на каз. яз. № {bRStudentGroup.Id} создан {userName} в {DateTime.Now}"
                };
                Context.Add(userActivity);
                await Context.SaveChangesAsync();
                ///***
                return RedirectToAction(nameof(Index));
            }

            return View(bRStudentGroup);
        }

        // *** конец создания потоков на рус яз

        // начало получения потоков каз студентов 
        public async Task<IActionResult> GetStudentGroupKazAsync(int id)
        {
            ViewBag.UserId = UserManager.GetUserId(HttpContext.User);
            var studentGroups = await Context.BRStudentGroup
                                   .Where(m => m.BMajorId == id)
                                   .Where(m => m.Type == "Kaz")
                                   .ToListAsync();
            return View(studentGroups);
        }

        //*** конец получения потоков на каз яз

        // начало создания потоков студентов на англ яз
        public async Task<IActionResult> CreateStudentGroupEngAsync(int id)
        {
            var bMajor = await Context.BMajor.Where(x => x.Id == id).FirstOrDefaultAsync();
            ViewBag.Id = id;
            ViewBag.Name = bMajor.Cypher;
            ViewBag.Type = "Eng";

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStudentGroupEngAsync([Bind("Name,Type,BMajorId")] BRStudentGroup bRStudentGroup)
        {
            string userName = UserManager.GetUserName(HttpContext.User);
            var phdContext = Context.BRStudentGroup.Include(b => b.BMajor);
            if (ModelState.IsValid)
            {
                Context.Add(bRStudentGroup);
                await Context.SaveChangesAsync();

                ////// DAUREN: ADDING USER LOGS
                UserActivity userActivity = new UserActivity()
                {
                    UserName = userName,
                    TimeStamp = DateTime.Now,
                    Activity = "Создание потока студентов на англ.яз.",
                    Description = $"Поток студентов на англ. яз. № {bRStudentGroup.Id} создан {userName} в {DateTime.Now}"
                };
                Context.Add(userActivity);
                await Context.SaveChangesAsync();
                ///***
                return RedirectToAction(nameof(Index));
            }
            return View(bRStudentGroup);
        }

        // *** конец создания потоков на англ. яз.

        // начало получения потоков англ. студентов 
        public async Task<IActionResult> GetStudentGroupEngAsync(int id)
        {
            ViewBag.UserId = UserManager.GetUserId(HttpContext.User);
            var studentGroups = await Context.BRStudentGroup
                                   .Where(m => m.BMajorId == id)
                                   .Where(m => m.Type == "Eng")
                                   .ToListAsync();
            return View(studentGroups);
        }

        //*** конец получения потоков на англ. яз

        // ******************************************************************************************************
        // конец создания всех потоков




        // начало создания студентов
        public async Task<IActionResult> CreateStudentAsync(int id)
        {
            ViewBag.Id = id;
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStudentAsync([Bind("Iin,Fname,Mname,Lname,ThesisTopicRus,ThesisTopicKaz,ThesisTopicEng,ResearchSupervisorFname,ResearchSupervisorMname,ResearchSupervisorLname,ResearchSupervisorWorkPlace,ResearchSupervisorPosition,ReviewerFname,ReviewerMname,ReviewerLname,ReviewerWorkPlace,ReviewerPosition,ReviewerGrade,ConsultantFname,ConsultantMname,ConsultantLname,ConsultantWorkPlace,ConsultantPosition,BRStudentGroupId")] BRStudent bRStudent)
        {
            string userName = UserManager.GetUserName(HttpContext.User);
            if (ModelState.IsValid)
            {
                Context.Add(bRStudent);
                await Context.SaveChangesAsync();

                ////// DAUREN: ADDING USER LOGS
                UserActivity userActivity = new UserActivity()
                {
                    UserName = userName,
                    TimeStamp = DateTime.Now,
                    Activity = "Создание студента",
                    Description = $"Студент № {bRStudent.Id}, ИИН: {bRStudent.Iin}, создан {userName} в {DateTime.Now}"
                };
                Context.Add(userActivity);
                await Context.SaveChangesAsync();
                ///***



                return RedirectToAction(nameof(Success));
            }
            return View(bRStudent);
        }
        // конец создания студентов

        // начало получения студентов
        public async Task<IActionResult> GetStudentsAsync(int id)
        {
            ViewBag.UserId = UserManager.GetUserId(HttpContext.User);
            var students = await Context.BRStudent
                                   .Where(m => m.BRStudentGroupId == id)
                                   .ToListAsync();

            return View(students);
        }
        // конец получения студентов

        // начало создания оценки
        public async Task<IActionResult> CreateStudentGradeAsync(int studentId, string userId)
        {

            var bRStudentGrades = await Context.BRStudentGrade.ToListAsync();
            var condition = bRStudentGrades != null && bRStudentGrades.Any(x => x.UserId == userId && x.BRStudentId == studentId);
            if (!condition)
            {
                ViewBag.StudentId = studentId;
                ViewBag.UserId = UserManager.GetUserId(HttpContext.User);
            }
            else
            {
                return RedirectToAction(nameof(NotSuccess));
            }
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStudentGradeAsync([Bind("Value,BRStudentId,UserId")] BRStudentGrade bRStudentGrade)
        {
            string userName = UserManager.GetUserName(HttpContext.User);
            var studentIin = await Context.BRStudent
                                          .Where(x => x.Id == bRStudentGrade.BRStudentId)
                                          .Select(x => x.Iin)
                                          .FirstOrDefaultAsync();

            if (ModelState.IsValid)
            {
        
                Context.Update(bRStudentGrade);
                await Context.SaveChangesAsync();

                ////// DAUREN: ADDING USER LOGS
                UserActivity userActivity = new UserActivity()
                {
                    UserName = userName,
                    TimeStamp = DateTime.Now,
                    Activity = "Выставление оценки",
                    Description = $"Пользователь {userName} поставил оценку {bRStudentGrade.Value} студенту {studentIin.ToString()} в {DateTime.Now}"
                };
                Context.Add(userActivity);
                await Context.SaveChangesAsync();
                ///***




                return RedirectToAction(nameof(Success));
            }
            return View(bRStudentGrade);
        }

        [HttpGet]
        public async Task<IActionResult> GetStudentGradeAsync(int studentId)
        {
            var phdContext = await Context.BRStudentGroup
                                    .Include(b => b.BRStudent)
                                    .Where(b => b.Id == studentId)
                                    .FirstOrDefaultAsync();          // вытаскиваю все потоки студентов
                                                                     // чтобы дальше вытащить шифр специальности
            
            // НЕ УДАЛЯТЬ!!! синхронная реализация
            //var bMajors = await Context.BMajor.ToListAsync(); // вытаскиваю все специльности 
                                                                // чтобы дальше вытащить шифр специальности
            // НЕ УДАЛЯТЬ!!! синхронная реализация
            //var studentMajor = bMajors.Where(x => x.Id == phdContext.Id).FirstOrDefault(); // вытаскиваю специальность,
                                                                                             //из которой буду вытаскивать шифр

            // оптимизированный асинхронный метод
            var studentMajor = await Context.BMajor
                                            .Where(x => x.Id == phdContext.Id)
                                            .FirstOrDefaultAsync(); // оптимизированный асинхронный метод

            var student = await Context.BRStudent.Include(x => x.BRStudentGrade)
                                           .FirstOrDefaultAsync(x => x.Id == studentId);

            var grades = await Context.BRStudentGrade.Include(x => x.User)
                                                .Where(x => x.BRStudentId == studentId)
                                                .ToListAsync();

            List<User> usersFromGradesList = new List<User>();
            foreach (var g in grades)
            {
                usersFromGradesList.Add(new User
                {
                    Id = g.User.Id,
                    UserName = g.User.UserName,
                    NormalizedUserName = g.User.NormalizedUserName,
                    Email = g.User.Email,
                    EmailConfirmed = g.User.EmailConfirmed,
                    PasswordHash = g.User.PasswordHash,
                    SecurityStamp = g.User.SecurityStamp,
                    ConcurrencyStamp = g.User.ConcurrencyStamp,
                    PhoneNumber = g.User.PhoneNumber,
                    PhoneNumberConfirmed = g.User.PhoneNumberConfirmed,
                    TwoFactorEnabled = g.User.TwoFactorEnabled,
                    LockoutEnd = g.User.LockoutEnd,
                    LockoutEnabled = g.User.LockoutEnabled,
                    AccessFailedCount = g.User.AccessFailedCount,
                    LastName = g.User.LastName,
                    FirstName = g.User.FirstName,
                    MiddleName = g.User.MiddleName,
                    UName = g.User.UName,
                    BMajorId = g.User.BMajorId
                });
            }

            //////////// вывод ролей пользователя

            var users = await Context.Users.ToListAsync(); // берем всех имеющихся пользователей
            var roles = await Context.Roles.ToListAsync(); // берем все имеющиеся роли
            var userRoles = await Context.UserRoles.ToListAsync(); // берем все связи пользователей и ролей

            var userWithRolesList = new List<UserWithRoles>(users.Count);
            foreach (var user in usersFromGradesList)
            {
                // НЕ УДАЛЯТЬ !!! синхронная реализация
                //var roleIds = userRoles.Where(x => x.UserId == user.Id).Select(x => x.RoleId).ToList(); // список Id ролей которые прикреплены к определенному пользователю
                // НЕ УДАЛЯТЬ!!! синхронная реализация
                //var currentUserRoles = roles.Where(x => roleIds.Contains(x.Id)).Select(x => x.Name).ToList();

                //оптимизированный асинхронный метод
                var roleIds = await Context.UserRoles
                                           .Where(x => x.UserId == user.Id)
                                           .Select(x => x.RoleId)
                                           .ToListAsync(); //оптимизированный асинхронный метод
                
                //оптимизированный асинхронный метод
                var currentUserRoles = await Context.Roles
                                                    .Where(x => roleIds
                                                    .Contains(x.Id)).Select(x => x.Name)
                                                    .ToListAsync(); // оптимизированный асинхронный метод
                
                userWithRolesList.Add(new UserWithRoles(user.UserName, currentUserRoles.ToArray()));
            }

            StudentGradeViewModel model = new StudentGradeViewModel
            {
                StudentName = student.Lname,
                AverageGrade = student.BRStudentGrade.Average(x => x.Value),
                Users = users,
                Grades = grades,
                UserWithRoles = userWithRolesList,
                MajorCypher = studentMajor.Cypher.ToString()
            };

            return View(model);
        }

















        public async Task<IActionResult> Success()
        {
            return View();
        }

        public async Task<IActionResult> NotSuccess()
        {
            return View();
        }








    }
}
