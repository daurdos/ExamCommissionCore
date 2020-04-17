using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Phd.Models
{
    public class User : IdentityUser
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

 
        public int AcademicDepartmentId { get; set; } // модернизации логики, чтобы была связь с кафедрами
        public AcademicDepartment AcademicDepartment { get; set; }



        public int BMajorId { get; set; }
        public int BRExamCommissionId { get; set; }
        public int FacultyId { get; set; }












    }
}