using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Phd.Models
{
    public class BRStudentDoc
    {
        public int Id { get; set; }
        
        [Display(Name = "Название документа")]
        public string Name { get; set; }

        [Display(Name = "Описание документа")]
        public string Description { get; set; }

        [Display(Name = "Студент")]
        public int BRStudentId { get; set; }
        [Display(Name = "Студент")]
        public BRStudent BRStudent { get; set; }

        [Display(Name = "Тип документа")]
        public int StudentDocTypeId { get; set; }
        public StudentDocType StudentDocType { get; set; }

    }
}
