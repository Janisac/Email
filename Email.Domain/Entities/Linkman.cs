using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Email.Domain.Entities
{
    public class Linkman
    {
        public virtual string LinkmanId { get; set; }
        public virtual string Sender { get; set; }
        public virtual string Receiver { get; set; }
    }
}
