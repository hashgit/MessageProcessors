using log4net;
using Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageProcessors.Lib.Processors
{
    public class BirthDayMessageProcessor : ProcessorBase, IMessageProcessor
    {
        private ILog _logger = log4net.LogManager.GetLogger(typeof(BirthDayMessageProcessor));
        private string _filePath;

        public BirthDayMessageProcessor()
        {
            _filePath = ConfigurationManager.AppSettings["BirthDayMessagesFilePath"] + "\\Birthdays\\log.txt";
        }

        public void Process(Messages.MessageBase message)
        {
            var birthdayMessage = message as BirthDayMessage;
            if (birthdayMessage == null)
            {
                _logger.ErrorFormat("Invalid message type {0}", message.MessageType);
                return;
            }

            if (string.IsNullOrWhiteSpace(message.StandardMessageText))
            {
                _logger.ErrorFormat("Message has not text");
                return;
            }

            var model = new MessageProcessor.Models.BirthDayMessage
            {
                BirthDate = birthdayMessage.BirthDate,
                Gift = birthdayMessage.Gift,
                MessageId = birthdayMessage.MessageId,
                MessageType = birthdayMessage.MessageType,
                Name = birthdayMessage.Name,
                StandardMessageText = birthdayMessage.StandardMessageText.ToUpperInvariant()
            };

            var json = JsonConvert.SerializeObject(model);

            WriteToFile(json, _filePath);

            _logger.InfoFormat("Message {0} of type {1} dumped in file {2}.", message.MessageId, message.MessageType, _filePath);
        }
    }
}
