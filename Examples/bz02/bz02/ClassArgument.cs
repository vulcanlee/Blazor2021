using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bz02
{
    public class ClassArgument
    {
        public int MyInt { get; set; }
        public string MyString { get; set; }
        public DateTime MyDatetime { get; set; }

        public override string ToString()
        {
            return $"({MyInt} - {MyString} - {MyDatetime})";
        }
    }
}
