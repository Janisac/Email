using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Email.Domain.Entities
{    
    /// <summary>
    /// 编写持久化类,来映射成为数据库表
    /// </summary>
   public  class MessageInbox
    {
        public virtual string Sender { get; set; }
        public virtual string Receiver { get; set; }
        public virtual string Topic { get; set; }
        public virtual string Content { get; set; }
    }
}
