using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using NHibernate;

namespace Email.Data
{
    public  class MessageOutboxData
    {
        public MessageOutboxData()
        { }

        // 按发件人查询
        public IList GetMessageOutboxByReceiver(String Receiver)
        {
            NHibernateHelper helper = new NHibernateHelper();
            ISession session = helper.GetSession();
            return session.CreateCriteria(typeof(Email.Domain.Entities.MessageOutbox))
                .Add(NHibernate.Criterion.Restrictions.Eq("Sender", Receiver))
                .List();
        }

        // 按主题查询
        public IList GetMessageOutboxByTopic(String Topic)
        {
            NHibernateHelper helper = new NHibernateHelper();
            ISession session = helper.GetSession();
            return session.CreateCriteria(typeof(Email.Domain.Entities.MessageOutbox))
                .Add(NHibernate.Criterion.Restrictions.Eq("Topic", Topic))
                .List();
        }

        // 获取收件箱所有邮件
        public IList GetAllMessageOutbox()
        {
            NHibernateHelper helper = new NHibernateHelper();
            ISession session = helper.GetSession();
            return session.CreateCriteria(typeof(Email.Domain.Entities.MessageOutbox)).List();
        }
    }
}
