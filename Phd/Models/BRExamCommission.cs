using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Phd.Models
{
    public class BRExamCommission
    {
        public int Id { get; set; }

        [Display(Name = "Название на русс.яз.")]
        public string Name { get; set; }
        //public ICollection<User> User { get; set; } // модернизации логики, чтобы была связь с кафедрами
        public ICollection<BRStudentGroup> BRStudentGroup { get; set; }

        [Display(Name = "Специальность")]
        public int BMajorId { get; set; }

        [Display(Name = "Специальность")]
        public BMajor BMajor { get; set; }









        


    }
}
