using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    public class BirthDayMessage : MessageBase
    {
        public DateTime BirthDate { get; set; }
        public string Gift { get; set; }
    }
}
