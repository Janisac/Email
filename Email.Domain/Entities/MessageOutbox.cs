using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Email.Domain.Entities
{
    public  class MessageOutbox
    {
        public virtual string Sender { get; set; }
        public virtual string Receiver { get; set; }
        public virtual string Topic { get; set; }
        public virtual string Content { get; set; }
    }
}
