using Phd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phd.ViewModels
{
    public class StudentGradeViewModel
    {
        public int StudentId { get; set; }
        public string StudentFName { get; set; }
        public string StudentLName { get; set; }
        public string StudentMName { get; set; }
        public string StudentThesisName { get; set; }
        public double AverageGrade { get; set; }
        public string MajorCypher { get; set; } 
        public string MajorName { get; set; } 
        public string Chairman { get; set; }
        public string Secretary { get; set; }
        public string SupervisorLName { get; set; }
        public string SupervisorFName { get; set; }
        public string SupervisorMName { get; set; }
        public string ReviewerLName { get; set; }
        public string ReviewerFName { get; set; }
        public string ReviewerMName { get; set; }
        public int? ThesPagesNumber { get; set; }
        public int? DrawTablesNumber { get; set; }
        public string GeneralCharacteristic { get; set; }
        public string KnowledgeLevel { get; set; }
        public string GradeLetter { get; set; }




        public int? ReviewerGrade { get; set; }
        public string ProtocolNumber { get; set; }
        public string StatementNumber { get; set; }
        public string GroupNumber { get; set; }
        public string IndividualCypher { get; set; }
        public int? GradeGpa { get; set; }
        public string GradeTraditional { get; set; }
        public DateTime? ProtocolDate { get; set; }
        public int? Credit { get; set; }
        public string StudyYear { get; set; }
        public string AttestationType { get; set; }
        public string AcademicDepartment { get; set; }


        public List<BRStudent> BRStudents { get; set; }
        public List<User> UsersFromMajorList { get; set; } 


        public List<User> Users { get; set; }
        public List<BRStudentGrade> Grades { get; set; }
        public List<UserWithRoles> UserWithRoles { get; set; }

        

    }
}
