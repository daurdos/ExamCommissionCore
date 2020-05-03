using Org.BouncyCastle.Asn1.Mozilla;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Phd.Models
{
    public class BRStudent
    {
        // собственные данные
        public int Id { get; set; }

        [Required]
        [Display(Name = "ИИН")]
        [MaxLength(12)]
        [MinLength(12)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Только числовые значения")]
        public string Iin { get; set; }

        [Display(Name = "Имя")]
        public string Fname { get; set; }

        [Display(Name = "Отчество")]
        public string Mname { get; set; }

        [Display(Name = "Фамилия")]
        public string Lname { get; set; }

        [Display(Name = "Название диссертации на русс.яз.")]
        public string ThesisTopicRus { get; set; }

        [Display(Name = "Название диссертации на каз.яз.")]
        public string ThesisTopicKaz { get; set; }

        [Display(Name = "Название диссертации на англ.яз.")]
        public string ThesisTopicEng { get; set; }

        [Display(Name = "Кол-во страниц диссертации")]
        public int? ThesisPagesNumber { get; set; }  // добавил в соответсвии с презой

        [Display(Name = "Кол-во страниц таблиц и т.д.")]
        public int? DrawingsTablesNumber { get; set; } // добавил в соответсвии с презой

        [Display(Name = "Группа")]
        public string GroupNumber { get; set; } // добавил после выявления необходимости

        [Display(Name = "Индивидуальный шифр")]
        public string IndividualCypher { get; set; } // добавил после выявления необходимости

        [Display(Name = "Время на вопросы")]
        public int? TimeForQuestions { get; set; } // добавил после выявления необходимости

        [Display(Name = "Номер протокола")]
        public string SummarizedSheetNumber { get; set; } // добавил после выявления необходимости

        [Display(Name = "Номер ведомости")]
        public string StatementNumber { get; set; } // добавил после выявления необходимости

        [Display(Name = "Наличие диссертации")]
        public bool ProjectAvailability { get; set; } = false; // добавил после выявления необходимости на всякий случай

        [Display(Name = "Наличие таблиц и т.д.")]
        public bool DrawingsTablesAvailability { get; set; } = false; // добавил после выявления необходимости на всякий случай
        
        [Display(Name = "Наличие рецензии")]
        public bool ReviewAvailability { get; set; } = false; // добавил после выявления необходимости на всякий случай
        
        [Display(Name = "Наличие отзыва руководителя")]
        public bool FeedbackAvailability { get; set; } = false; // добавил после выявления необходимости на всякий случай 


        public double? AvegrageGrade { get; set; }
        public double? Gpa { get; set; }
        public string LetterGrade { get; set; }
        public string TraditionalGradeRus { get; set; }
        public string TraditionalGradeKaz { get; set; }
        public string TraditionalGradeEng { get; set; }





        // запасные поля

        public string ExtraString1 { get; set; } // прозапас
        public string ExtraString2 { get; set; } // прозапас
        public string ExtraString3 { get; set; } // прозапас
        public string ExtraString4 { get; set; } // прозапас
        public int? ExtraInt1 { get; set; } // прозапас
        public int? ExtraInt2 { get; set; } // прозапас
        public int? ExtraInt3 { get; set; } // прозапас
        public double? ExtraDouble1 { get; set; } // прозапас
        public double? ExtraDouble2 { get; set; } // прозапас
        public DateTime? ExtaDateTime1 { get; set; } // прозапас
        public DateTime? ExtraDateTime2 { get; set; } // прозапас
        public bool ExtraBool1 { get; set; } = false; // прозапас
        public bool ExatraBool2 { get; set; } = false; // прозапас
        public bool ExtraBool3 { get; set; } = true; // прозапас
                                                     // ************************



        // реквизиты научного руководителя ResearchSupervisor 
        [Display(Name = "Имя")]
        public string SupervisorFname { get; set; }

        [Display(Name = "Отчество")]
        public string SupervisorMname { get; set; }

        [Display(Name = "Фамилия")]
        public string SupervisorLname { get; set; }

        [Display(Name = "Место работы")]
        public string SupervisorWorkPlace { get; set; }

        [Display(Name = "Должность")]
        public string SupervisorPosition { get; set; }

        [Display(Name = "Степень")]
        public string SupervisorAcademicDegree { get; set; } // добавил с презы, данные будут с соотв таблицы !!!!!!
        
        [Display(Name = "Должность")]
        public string SupervisorReviewAvailability { get; set; } // добавил с презы, данные enum Availability
        [Display(Name = "Наличие отзыва руководителя")]
        public string SupervisorConclusion { get; set; } // добавил с презы, данные enum Conclusion
        // ***

        // реквизиты рецензента Reviewer
        [Display(Name = "Имя")]
        public string ReviewerFname { get; set; }
        [Display(Name = "Фамилия")]
        public string ReviewerMname { get; set; }
        [Display(Name = "Отчество")]
        public string ReviewerLname { get; set; }
        [Display(Name = "Место работы")]
        public string ReviewerWorkPlace { get; set; }
        [Display(Name = "Должность")]
        public string ReviewerPosition { get; set; }
        [Display(Name = "Степень")]
        public string ReviewerAcademicDegree { get; set; }
        [Display(Name = "Оценка рецензента")]
        public int? ReviewerGrade { get; set; }
        [Display(Name = "Наличие рецензии")]
        public string ReviewerReviewAvailability { get; set; } // добавил с презы, данные enum Availability
        // ***

        // реквизиты консультанта Consultant
        [Display(Name = "Имя")]
        public string ConsultantFname { get; set; }
        [Display(Name = "Отчество")]
        public string ConsultantMname { get; set; }
        [Display(Name = "Фамилия")]
        public string ConsultantLname { get; set; }
        [Display(Name = "Место работы")]
        public string ConsultantWorkPlace { get; set; }
        [Display(Name = "Должность")]
        public string ConsultantPosition { get; set; }
        [Display(Name = "Степень")]
        public string ConsultantAcademicDegree { get; set; } // добавил с презы, данные будут с соотв таблицы !!!!!!!
        // ***

        // Сведения по защите
        [Display(Name = "Номер протокола")]
        public string ProtocolNumber { get; set; }
        [Display(Name = "Дата защиты")]
        public DateTime? DefenceDate { get; set; }

        [Display(Name = "Тип аттестации")]
        public string TypeOfStateAttestation { get; set; }

        [Display(Name = "Кол-во кредитов")]
        public int? CreditNumber { get; set; }

        [Display(Name = "Год обучения")]
        public string StudyYear { get; set; } // добавил с презы, данные будут с соотв таблицы !!!!!!!!!!!!

        [Display(Name = "Начало")]
        public DateTime? StartTime { get; set; }

        [Display(Name = "Конец")]
        public DateTime? EndTime { get; set; }

        [Display(Name = "Общая характеристика ответов")]
        public string AnswerCharacteristic { get; set; }

        [Display(Name = "Уровень подготовки")]
        public string LevelOfPreparation { get; set; }

        [Display(Name = "Отсутствующий член")]
        public string AbsentMemberFullName { get; set; }
        // ***




        /// Привязанность к одной группе
        public int BRStudentGroupId { get; set; }
        public BRStudentGroup BRStudentGroup { get; }
        // ***

        // Все связи один ко многим
        public ICollection<BRStudentGrade> BRStudentGrade { get; set; }
        public ICollection<BRStudentDoc> BRStudentDoc { get; set; }
        // ***


            // constructor
        public BRStudent()
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
