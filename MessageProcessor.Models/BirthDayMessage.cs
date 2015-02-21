using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageProcessor.Models
{
    public class BirthDayMessage
    {
        public Guid MessageId { get; set; }
        public string MessageType { get; set; }
        public string Name { get; set; }
        public string StandardMessageText { get; set; }

        public DateTime BirthDate { get; set; }
        public string Gift { get; set; }
    }
}
