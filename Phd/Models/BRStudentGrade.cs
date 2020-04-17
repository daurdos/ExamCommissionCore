using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Phd.Models
{
    public class BRStudentGrade
    {
        public int Id { get; set; }

        [Display(Name = "Оценка (%)")]
        public int Value { get; set; }

        [Display(Name = "Студент")]
        public int BRStudentId { get; set; }
        [Display(Name = "Студент")]
        public BRStudent BRStudent { get; set; }

        [Display(Name = "От преподавателя")]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
