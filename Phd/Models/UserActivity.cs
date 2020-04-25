using Org.BouncyCastle.Asn1.Cms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phd.Models
{
    public class UserActivity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Activity { get; set; }
        public string Description { get; set; }

    }
}
