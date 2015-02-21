using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    // main message
    public abstract class MessageBase
    {
        public Guid MessageId { get; set; }
        public string MessageType { get; set; }
        public string Name { get; set; }
        public string StandardMessageText { get; set; }
    }
}
