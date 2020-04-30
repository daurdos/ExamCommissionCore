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


        // запасные поля
        public string? ExtraString1 { get; set; } // прозапас
        public string? ExtraString2 { get; set; } // прозапас
        public int? ExtraInt1 { get; set; } // прозапас
        public double ExtraDouble1 { get; set; } // прозапас
        public DateTime? ExtaDateTime1 { get; set; } // прозапас
        public bool ExtraBool1 { get; set; } = false; // прозапас
        public bool ExtraBool3 { get; set; } = true; // прозапас
        // ************************

    }
}
