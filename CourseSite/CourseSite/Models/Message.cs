using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseSite.Models
{

    public class From
    {
        public string Email { get; set; }
        public string Name { get; set; }
    }

    public class To
    {
        public string Email { get; set; }
        public string Name { get; set; }
    }

    public class Message
    {
        public From From { get; set; }
        public List<To> To { get; set; }
        public string Subject { get; set; }
        public string TextPart { get; set; }
    }

    public class RootObject
    {
        public List<Message> Messages { get; set; }
    }
}