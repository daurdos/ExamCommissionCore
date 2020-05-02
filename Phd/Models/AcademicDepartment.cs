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








        // запасные поля
        public string ExtraString1 { get; set; } // прозапас
        public string ExtraString2 { get; set; } // прозапас
        public int? ExtraInt1 { get; set; } // прозапас
        public double? ExtraDouble1 { get; set; } // прозапас
        public DateTime? ExtaDateTime1 { get; set; } // прозапас
        public bool ExtraBool1 { get; set; } = false; // прозапас
        public bool ExtraBool3 { get; set; } = true; // прозапас
        // ************************


    }
}
