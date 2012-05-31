using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using Email.Domain.Entities;
using System.Collections;

namespace Email.Data
{
    public class MessageInboxData
    {
        public MessageInboxData()
        { }
        /*protected ISession Session { get; set; }
        public MessageInboxData(ISession session)
        {
            Session = session;
        }*/

        /*public void CreateMessageInbox(MessageInbox emailInfo)
        {
            
            Session.Save(emailInfo);
            //Session.Flush();
            Session.Close();
        }*/
       
     /*  public bool Update(User userInfo)
       {
           ITransaction transaction = Session.BeginTransaction(); 
           try { Session.Update(userInfo); transaction.Commit(); return true; }
           catch (Exception e) { transaction.Rollback(); return false; } 
           finally { Session.Close(); }
       }
       public bool Delete(User userInfo) 
       { 
           ITransaction transaction = Session.BeginTransaction(); 
           try { Session.Delete(userInfo); transaction.Commit(); return true; }
           catch (Exception e) { transaction.Rollback(); return false; }
           finally { Session.Close(); }
       }*/

        // 按发件人查询
        public IList GetMessageInboxBySender(String Sender)
        {
            NHibernateHelper helper = new NHibernateHelper();
            ISession session = helper.GetSession();
            //return Session.Get<MessageInbox>(Sender);
            return session.CreateCriteria(typeof(Email.Domain.Entities.MessageInbox))
                .Add(NHibernate.Criterion.Restrictions.Eq("Sender", Sender))
                .List();
        }
       
        // 按主题查询
        public IList GetMessageInboxByTopic(String Topic)
        {
            NHibernateHelper helper = new NHibernateHelper();
            ISession session = helper.GetSession();
            return session.CreateCriteria(typeof(Email.Domain.Entities.MessageInbox))
                .Add(NHibernate.Criterion.Restrictions.Eq("Topic", Topic))
                .List();
        }

        // 获取收件箱所有邮件
        public IList GetAllMessageInbox()
        {
            NHibernateHelper helper = new NHibernateHelper();
            ISession session = helper.GetSession();
            return session.CreateCriteria(typeof(Email.Domain.Entities.MessageInbox)).List();
        }
    }
}
