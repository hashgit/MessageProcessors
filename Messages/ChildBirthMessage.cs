using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    public enum Gender
    {
        Male,
        Female
    }

    public class ChildBirthMessage : MessageBase
    {
        public Gender Gender { get; set; }
        public DateTime BabyBirthDay { get; set; }
    }
}
