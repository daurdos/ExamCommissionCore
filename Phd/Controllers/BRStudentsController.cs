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
    public class BRStudentsController : Controller
    {
        private readonly PhdContext _context;

        public BRStudentsController(PhdContext context)
        {
            _context = context;
        }

        // GET: BRStudents
        public async Task<IActionResult> Index()
        {
            return View(await _context.BRStudent.ToListAsync());
        }

        // GET: BRStudents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bRStudent = await _context.BRStudent
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
            return View();
        }

        // POST: BRStudents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Iin,Fname,Mname,Lname,ThesisTopicRus,ThesisTopicKaz,ThesisTopicEng,ThesisPagesNumber,DrawingsTablesNumber,SupervisorFname,SupervisorMname,SupervisorLname,SupervisorWorkPlace,SupervisorPosition,SupervisorAcademicDegree,SupervisorReviewAvailability,SupervisorConclusion,ReviewerFname,ReviewerMname,ReviewerLname,ReviewerWorkPlace,ReviewerPosition,ReviewerAcademicDegree,ReviewerGrade,ReviewerReviewAvailability,ConsultantFname,ConsultantMname,ConsultantLname,ConsultantWorkPlace,ConsultantPosition,ConsultantAcademicDegree,ProtocolNumber,DefenceDate,TypeOfStateAttestation,CreditNumber,StudyYear,StartTime,EndTime,AnswerCharacteristic,LevelOfPreparation,AbsentMemberFullName,BRStudentGroupId")] BRStudent bRStudent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bRStudent);
                await _context.SaveChangesAsync();
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

            var bRStudent = await _context.BRStudent.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Iin,Fname,Mname,Lname,ThesisTopicRus,ThesisTopicKaz,ThesisTopicEng,ThesisPagesNumber,DrawingsTablesNumber,SupervisorFname,SupervisorMname,SupervisorLname,SupervisorWorkPlace,SupervisorPosition,SupervisorAcademicDegree,SupervisorReviewAvailability,SupervisorConclusion,ReviewerFname,ReviewerMname,ReviewerLname,ReviewerWorkPlace,ReviewerPosition,ReviewerAcademicDegree,ReviewerGrade,ReviewerReviewAvailability,ConsultantFname,ConsultantMname,ConsultantLname,ConsultantWorkPlace,ConsultantPosition,ConsultantAcademicDegree,ProtocolNumber,DefenceDate,TypeOfStateAttestation,CreditNumber,StudyYear,StartTime,EndTime,AnswerCharacteristic,LevelOfPreparation,AbsentMemberFullName,BRStudentGroupId")] BRStudent bRStudent)
        {
            if (id != bRStudent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bRStudent);
                    await _context.SaveChangesAsync();
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

            var bRStudent = await _context.BRStudent
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
            var bRStudent = await _context.BRStudent.FindAsync(id);
            _context.BRStudent.Remove(bRStudent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BRStudentExists(int id)
        {
            return _context.BRStudent.Any(e => e.Id == id);
        }
    }
}
