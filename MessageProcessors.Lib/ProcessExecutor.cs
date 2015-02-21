using log4net;
using MessageProcessors.Lib;
using Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageProcessors.Lib
{
    // interface, if using IoC
    public interface IProcessExecutor
    {
        bool Process(MessageBase message);
    }

    public class ProcessExecutor : IProcessExecutor
    {
        private ILog _logger;

        public ProcessExecutor()
        {
            _logger = log4net.LogManager.GetLogger(typeof(ProcessExecutor));
        }

        public bool Process(MessageBase message)
        {
            if (message == null) return false;
            if (string.IsNullOrWhiteSpace(message.MessageType))
            {
                _logger.Error("Message Type not present");
                return false;
            }

            var processor = GetProcessor(message.MessageType);
            if (processor == null)
            {
                _logger.ErrorFormat("Invalid message type {1}", message.MessageType);
                return false;
            }

            try
            {
                processor.Process(message);
            }
            catch (Exception e)
            {
                _logger.ErrorFormat("Failed to process message of type {0}.", message.MessageType);
                _logger.Error(e.StackTrace);
                return false;
            }

            return true;
        }

        private IMessageProcessor GetProcessor(string messageType)
        {
            // create a processor for this message processor
            Type processorType = Type.GetType("MessageProcessors.Lib.Processors." + messageType + "MessageProcessor", false, true);
            if (processorType == null) return null;

            return (IMessageProcessor) Activator.CreateInstance(processorType);
        }
    }
}
