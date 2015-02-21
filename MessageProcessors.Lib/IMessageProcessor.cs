using Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageProcessors.Lib
{
    public interface IMessageProcessor
    {
        void Process(MessageBase message);
    }
}
