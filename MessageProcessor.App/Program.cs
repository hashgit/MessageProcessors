using Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageProcessor.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var messages = new MessageBase[2];
            messages[0] = new BirthDayMessage()
            {
                 MessageId = Guid.NewGuid(),
                 MessageType = "birthday",
                 Name = "Tony Abbot",
                 StandardMessageText = "Happy Birthday Mate",
                 Gift = "TimTam",
                 BirthDate = DateTime.Parse("01/10/1958")
            };
            messages[1] = new ChildBirthMessage()
            {
                MessageId = Guid.NewGuid(),
                MessageType = "childbirth",
                Name = "Tony Abbot",
                StandardMessageText = "Happy Birthday Mate",
                Gender = Messages.Gender.Female,
                BabyBirthDay = DateTime.Parse("11/03/2015")
            };


            var processorManager = new MessageProcessors.Lib.ProcessExecutor();

            Array.ForEach(messages, message =>
                {
                    if (processorManager.Process(message))
                    {
                        Console.WriteLine("Processed successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Execution failed for message type {0}", message.MessageType);
                    }
                });


            Console.ReadKey();
            
        }
    }
}
