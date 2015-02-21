using log4net;
using Messages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MessageProcessors.Lib.Processors
{
    public class ChildBirthMessageProcessor : ProcessorBase, IMessageProcessor
    {
        private ILog _logger = log4net.LogManager.GetLogger(typeof(ChildBirthMessageProcessor));
        private string _filePath;

        public ChildBirthMessageProcessor()
        {
            _filePath = ConfigurationManager.AppSettings["ChildBirthMessagesFilePath"] + "\\BabyBirth\\log.txt";
        }

        public void Process(Messages.MessageBase message)
        {
            var childBirthMessage = message as ChildBirthMessage;
            if (childBirthMessage == null)
            {
                _logger.ErrorFormat("Invalid message type {0}", message.MessageType);
                return;
            }

            if (string.IsNullOrWhiteSpace(message.StandardMessageText) || string.IsNullOrWhiteSpace(message.Name))
            {
                _logger.ErrorFormat("Message should have both Name and StandardMessageText");
                return;
            }

            var model = new MessageProcessor.Models.ChildBirthMessage
            {
                MessageId = childBirthMessage.MessageId,
                Gender = childBirthMessage.Gender == Gender.Female ? MessageProcessor.Models.Gender.Female : MessageProcessor.Models.Gender.Male,
                MessageType = childBirthMessage.MessageType,
                StandardMessageText = childBirthMessage.StandardMessageText,
                Name = Convert.ToBase64String(Encoding.ASCII.GetBytes(childBirthMessage.Name)),
                BabyBirthDay = childBirthMessage.BabyBirthDay.ToString("dd MMM yyyy")
            };

            var xml = GetMessageXml(model);
            WriteToFile(xml, _filePath);

            _logger.InfoFormat("Message {0} of type {1} dumped in file {2}.", message.MessageId, message.MessageType, _filePath);
        }

        private string GetMessageXml(MessageProcessor.Models.ChildBirthMessage model)
        {
            var stringwriter = new System.IO.StringWriter();
            var serializer = new XmlSerializer(model.GetType());
            serializer.Serialize(stringwriter, model);
            return stringwriter.ToString();
        }
    }
}
