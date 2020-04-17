using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Phd.Models
{
    public class BRStudent
    {
        public int Id { get; set; }

        [Display(Name = "ФИО")]
        public string Name { get; set; }
        public ICollection<BRStudentGrade> BRStudentGrade { get; set; }
        public ICollection<BRStudentDoc> BRStudentDoc { get; set; }

        [Display(Name = "Поток  ГАК")]
        public int BRStudentGroupId { get; set; }
        [Display(Name = "Поток  ГАК")]
        public BRStudentGroup BRStudentGroup { get; }
    }
}
