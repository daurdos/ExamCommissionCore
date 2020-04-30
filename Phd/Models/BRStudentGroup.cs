using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Phd.Models
{
    public class BRStudentGroup
    {
        public int Id { get; set; }

        [Display(Name = "Поток по защите ГАК")]
        public string Name { get; set; }
        public string Type { get; set; }


        // запасные поля
        public string ExtraString1 { get; set; } // прозапас
        public string ExtraString2 { get; set; } // прозапас
        public int? ExtraInt1 { get; set; } // прозапас
        public double? ExtraDouble1 { get; set; } // прозапас
        public DateTime? ExtaDateTime1 { get; set; } // прозапас
        public bool ExtraBool1 { get; set; } = false; // прозапас
        public bool ExtraBool3 { get; set; } = true; // прозапас
        // ************************




        public ICollection<BRStudent> BRStudent { get; set; }

        [Display(Name = "Комиссия")]
        public int BMajorId { get; set; }
        [Display(Name = "Комиссия")]
        public BMajor BMajor { get; set; }

    }
}
