using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Message
    {
        public int Key { get; set; }
        public string Name { get; set; }
        public string MailAddress { get; set; }
        public string Subject { get; set; }
         public string message { get; set; }

        public override string ToString()
        {
            return this.ToStringProperty();
        }
    }
}
