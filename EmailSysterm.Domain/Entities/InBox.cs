using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmailSysterm.Domain.Entities
{    
    /// <summary>
    /// 编写持久化类,来映射成为数据库表
    /// </summary>
   public  class InBox
    {
        public virtual string Addressor { get; set; }
        public virtual string Addressee { get; set; }
        public virtual string Title { get; set; }
        public virtual string Content { get; set; }
    }
}
