using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Phd.Models
{
    public class StudentDocType
    {
        public int Id { get; set; }
        
        [Display(Name = "Название типа документа")]
        public string Name { get; set; }
        public ICollection<BRStudentDoc> BRStudentDoc { get; set; }
    }
}
