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
        public string Opinion { get; set; }  // добавил в соотвествии с презентацией
        public string Question { get; set; } // добавил в соотвествии с презентацией


        // запасные поля
        public string ExtraString1 { get; set; } // прозапас
        public string ExtraString2 { get; set; } // прозапас
        public int? ExtraInt1 { get; set; } // прозапас
        public double? ExtraDouble1 { get; set; } // прозапас
        public DateTime? ExtaDateTime1 { get; set; } // прозапас
        public bool ExtraBool1 { get; set; } = false; // прозапас
        public bool ExtraBool3 { get; set; } = true; // прозапас
        // ************************





        // связи
        public int BRStudentId { get; set; }
        public BRStudent BRStudent { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        // ***




    }
}
