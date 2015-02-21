using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageProcessor.Models
{
    public class ChildBirthMessage
    {
        public Guid MessageId { get; set; }
        public string MessageType { get; set; }
        public string Name { get; set; }
        public string StandardMessageText { get; set; }

        public Gender Gender { get; set; }
        public string BabyBirthDay { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
