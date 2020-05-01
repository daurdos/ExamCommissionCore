using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phd.Models
{
    public class GradesTable
    {
        public int Id { get; set; }
        public double? AvegrageGrade { get; set; }
        public double? Gpa { get; set; }
        public string LetterGrade { get; set; }
        public string TraditionalGradeRus { get; set; }
        public string TraditionalGradeKaz { get; set; }
        public string TraditionalGradeEng { get; set; }


        // запасные поля
        public string ExtraString1 { get; set; } // прозапас
        public string ExtraString2 { get; set; } // прозапас
        public int? ExtraInt1 { get; set; } // прозапас
        public double? ExtraDouble1 { get; set; } // прозапас
        public DateTime? ExtaDateTime1 { get; set; } // прозапас
        public bool ExtraBool1 { get; set; } = false; // прозапас
        public bool ExtraBool3 { get; set; } = true; // прозапас
                                                     // ************************



        // constructor
        public GradesTable()
        {
            AvegrageGrade = 0.00;
            Gpa = 0;
            LetterGrade = "Not specified";
            TraditionalGradeRus = "Оценки не высталены";
            TraditionalGradeKaz = "Бага койылмаган";
            TraditionalGradeEng = "Grades not specified";
        }

    }
}
