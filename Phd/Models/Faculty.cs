using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Phd.Models
{
    public class Faculty
    {
        public int Id { get; set; }

        [Display(Name = "Название факультета на русс.яз.")]
        public string NameRus { get; set; }
        [Display(Name = "Название факультета на каз.яз.")]
        public string NameKaz { get; set; }
        [Display(Name = "Название факультета на англ.яз.")]
        public string NameEng { get; set; }
        public ICollection<AcademicDepartment> AcademicDepartment { get; set; }


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
