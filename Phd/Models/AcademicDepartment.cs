using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Phd.Models
{
    public class AcademicDepartment
    {
        public int Id { get; set; }
        
        [Display(Name = "Название")]
        public string NameRus { get; set; }
        public string NameKaz { get; set; }
        public string NameEng { get; set; }


        [Display(Name = "Факультет")]
        public int FacultyId { get; set; }

        [Display(Name = "Факультет")]
        public Faculty Faculty { get; set; }
        public ICollection<BMajor> BMajor { get; set; }
        public ICollection<BDirection> BDirection { get; set; }

    }
}
