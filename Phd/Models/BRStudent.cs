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
        public string Iin { get; set; }
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Lname { get; set; }
        public string ThesisTopicRus { get; set; }
        public string ThesisTopicKaz { get; set; }
        public string ThesisTopicEng { get; set; }
        public int? ThesisPagesNumber { get; set; }  // добавил в соответсвии с презой
        public int? DrawingsTablesNumber { get; set; } // добавил в соответсвии с презой
        public string GroupNumber { get; set; } // добавил после выявления необходимости
        public string IndividualCypher { get; set; } // добавил после выявления необходимости
        public int? TimeForQuestions { get; set; } // добавил после выявления необходимости
        public string SummarizedSheetNumber { get; set; } // добавил после выявления необходимости
        public string StatementNumber { get; set; } // добавил после выявления необходимости
        public bool ProjectAvailability { get; set; } = false; // добавил после выявления необходимости на всякий случай
        public bool DrawingsTablesAvailability { get; set; } = false; // добавил после выявления необходимости на всякий случай
        public bool ReviewAvailability { get; set; } = false; // добавил после выявления необходимости на всякий случай
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
        public string SupervisorFname { get; set; }
        public string SupervisorMname { get; set; }
        public string SupervisorLname { get; set; }
        public string SupervisorWorkPlace { get; set; }
        public string SupervisorPosition { get; set; }
        public string SupervisorAcademicDegree { get; set; } // добавил с презы, данные будут с соотв таблицы !!!!!!
        public string SupervisorReviewAvailability { get; set; } // добавил с презы, данные enum Availability
        public string SupervisorConclusion { get; set; } // добавил с презы, данные enum Conclusion
        // ***

        // реквизиты рецензента Reviewer
        public string ReviewerFname { get; set; }
        public string ReviewerMname { get; set; }
        public string ReviewerLname { get; set; }
        public string ReviewerWorkPlace { get; set; }
        public string ReviewerPosition { get; set; }
        public string ReviewerAcademicDegree { get; set; }
        public int? ReviewerGrade { get; set; }
        public string ReviewerReviewAvailability { get; set; } // добавил с презы, данные enum Availability
        // ***

        // реквизиты консультанта Consultant
        public string ConsultantFname { get; set; }
        public string ConsultantMname { get; set; }
        public string ConsultantLname { get; set; }
        public string ConsultantWorkPlace { get; set; }
        public string ConsultantPosition { get; set; }
        public string ConsultantAcademicDegree { get; set; } // добавил с презы, данные будут с соотв таблицы !!!!!!!
        // ***

        // Сведения по защите
        public string ProtocolNumber { get; set; }
        public DateTime? DefenceDate { get; set; }
        public string TypeOfStateAttestation { get; set; }
        public int? CreditNumber { get; set; }
        public string StudyYear { get; set; } // добавил с презы, данные будут с соотв таблицы !!!!!!!!!!!!
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string AnswerCharacteristic { get; set; }
        public string LevelOfPreparation { get; set; }
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
