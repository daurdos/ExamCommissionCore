using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Phd.Models
{
    public class BMajor
    {
        public int Id { get; set; }

        [Display(Name = "Шифр специальности")]
        public string Cypher { get; set; }

        [Display(Name = "Название на русс.яз.")]
        public string NameRus { get; set; }

        [Display(Name = "Название на каз.яз.")]
        public string NameKaz { get; set; }

        [Display(Name = "Название на англ.яз.")]
        public string NameEng { get; set; }

        public string StatementNumber { get; set; }
        public string AttestationTypeRus { get; set; }
        public string AttestationTypeKaz { get; set; }
        public int? Credits { get; set; }
        public string StudyYear { get; set; }



        [Display(Name = "Кафедра")]
        public int AcademicDepartmentId { get; set; }
        [Display(Name = "Кафедра")]
        public AcademicDepartment AcademicDepartment { get; set; }





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
