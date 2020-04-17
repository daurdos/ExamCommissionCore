using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phd
{
    public class BaseClass : BaseClass<string>
    {
        public BaseClass()
        {
            
        }
    }


    public class BaseClass<TKey> where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; }
    }
}
