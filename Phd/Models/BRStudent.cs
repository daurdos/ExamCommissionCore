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



        public string ReturnGradeLetter(double grade)
        {
            string letter = "No grade";

            if ((grade <= 100) && (grade >= 95))
            {
                return letter = "A";
            }
            if ((grade <= 94) && (grade >= 90))
            {
                return letter = "A-";
            }
            if ((grade <= 89) && (grade >= 85))
            {
                return letter = "B+";
            }
            if ((grade <= 84) && (grade >= 80))
            {
                return letter = "B";
            }
            if ((grade <= 79) && (grade >= 75))
            {
                return letter = "B-";
            }
            if ((grade <= 74) && (grade >= 70))
            {
                return letter = "C+";
            }
            if ((grade <= 69) && (grade >= 65))
            {
                return letter = "C";
            }
            if ((grade <= 64) && (grade >= 60))
            {
                return letter = "C-";
            }
            if ((grade <= 59) && (grade >= 55))
            {
                return letter = "D+";
            }
            if ((grade <= 54) && (grade >= 50))
            {
                return letter = "D-";
            }
            if ((grade <= 49) && (grade >= 25))
            {
                return letter = "FX";
            }
            if ((grade <= 24) && (grade >= 0))
            {
                return letter = "F";
            }

            return letter;
        }






        public double ReturnGpa(double grade)
        {
            double gpa = 0;

            if ((grade <= 100) && (grade >= 95))
            {
                return gpa = 4.0;
            }
            if ((grade <= 94) && (grade >= 90))
            {
                return gpa = 3.67;
            }
            if ((grade <= 89) && (grade >= 85))
            {
                return gpa = 3.33;
            }
            if ((grade <= 84) && (grade >= 80))
            {
                return gpa = 3.0;
            }
            if ((grade <= 79) && (grade >= 75))
            {
                return gpa = 2.67;
            }
            if ((grade <= 74) && (grade >= 70))
            {
                return gpa = 2.33;
            }
            if ((grade <= 69) && (grade >= 65))
            {
                return gpa = 2.0;
            }
            if ((grade <= 64) && (grade >= 60))
            {
                return gpa = 1.67;
            }
            if ((grade <= 59) && (grade >= 55))
            {
                return gpa = 1.33;
            }
            if ((grade <= 54) && (grade >= 50))
            {
                return gpa = 1.0;
            }
            if ((grade <= 49) && (grade >= 25))
            {
                return gpa = 0.5;
            }
            if ((grade <= 24) && (grade >= 0))
            {
                return gpa = 0;
            }

            return gpa;
        }




        public string ReturnGradeTraditionalRus(double grade)
        {
            string letter = "No grade";

            if ((grade <= 100) && (grade >= 90))
            {
                return letter = "Отлично";
            }

            if ((grade <= 89) && (grade >= 70))
            {
                return letter = "Хорошо";
            }
            
            if ((grade <= 69) && (grade >= 50))
            {
                return letter = "Удовлетворительно";
            }

            if ((grade <= 49) && (grade >= 0))
            {
                return letter = "Неудовлетворительно";
            }

            return letter;
        }



        public string ReturnGradeTraditionalKaz(double grade)
        {
            string letter = "No grade";

            if ((grade <= 100) && (grade >= 90))
            {
                return letter = "Өте жақсы";
            }

            if ((grade <= 89) && (grade >= 70))
            {
                return letter = "Жақсы";
            }

            if ((grade <= 69) && (grade >= 50))
            {
                return letter = "Қанағаттанарлық";
            }

            if ((grade <= 49) && (grade >= 0))
            {
                return letter = "Қанағаттанарлықсыз";
            }

            return letter;
        }





        public string ReturnGradeTraditionalEng(double grade)
        {
            string letter = "No grade";

            if ((grade <= 100) && (grade >= 90))
            {
                return letter = "Excellent";
            }

            if ((grade <= 89) && (grade >= 70))
            {
                return letter = "Good";
            }

            if ((grade <= 69) && (grade >= 50))
            {
                return letter = "Satisfactory";
            }

            if ((grade <= 49) && (grade >= 0))
            {
                return letter = "Unsatisfactory";
            }

            return letter;
        }





    }
}
