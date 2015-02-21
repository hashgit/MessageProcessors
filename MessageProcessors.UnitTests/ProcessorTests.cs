using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Messages;
using MessageProcessors.Lib;

namespace MessageProcessors.UnitTests
{
    [TestClass]
    public class ProcessorTests
    {
        [TestInitialize]
        public void InitTest()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        [TestMethod]
        public void CanProcessBirthDayMessage()
        {
            var message = new BirthDayMessage()
            {
                 MessageId = Guid.NewGuid(),
                 MessageType = "birthday",
                 Name = "Tony Abbot",
                 StandardMessageText = "Happy Birthday Mate",
                 Gift = "TimTam",
                 BirthDate = DateTime.Parse("01/10/1958")
            };

            var executor = new ProcessExecutor();
            var result = executor.Process(message);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void FailWithWrongMessageType()
        {
            var message = new BirthDayMessage()
            {
                MessageId = Guid.NewGuid(),
                MessageType = "abc",
                Name = "Tony Abbot",
                StandardMessageText = "Happy Birthday Mate",
                Gift = "TimTam",
                BirthDate = DateTime.Parse("01/10/1958")
            };

            var executor = new ProcessExecutor();
            var result = executor.Process(message);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CanProcessChildBirthMessage()
        {
            var message = new ChildBirthMessage()
            {
                MessageId = Guid.NewGuid(),
                MessageType = "childbirth",
                Name = "Tony Abbot",
                StandardMessageText = "Happy Birthday Mate",
                Gender = Messages.Gender.Female,
                BabyBirthDay = DateTime.Parse("11/03/2015")
            };

            var executor = new ProcessExecutor();
            var result = executor.Process(message);

            Assert.IsTrue(result);
        }
    }
}
