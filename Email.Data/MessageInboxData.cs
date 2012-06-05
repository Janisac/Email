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
        public IList<MessageInbox> GetMessageInboxBySender(String Sender)
        {
            NHibernateHelper helper = new NHibernateHelper();
            ISession session = helper.GetSession();
            try
            {
                ICriteria crit1 = session.CreateCriteria(typeof(Email.Domain.Entities.MessageInbox))
                                .Add(NHibernate.Criterion.Restrictions.Eq("Receiver",UserHelper.uEmail ))
                               .Add(NHibernate.Criterion.Restrictions.Eq("Sender", Sender));
                  crit1.SetMaxResults(50);
                IList<MessageInbox> messagesin1 = crit1.List<MessageInbox>();
                return messagesin1;
            }
            catch (Exception e)
            { throw e; }   
        }
       
        // 按主题查询
        public IList<MessageInbox> GetMessageInboxByTopic(String Topic)
        {
            NHibernateHelper helper = new NHibernateHelper();
            ISession session = helper.GetSession();
            try
            {
                ICriteria crit2 = session.CreateCriteria(typeof(Email.Domain.Entities.MessageInbox))
                                 .Add(NHibernate.Criterion.Restrictions.Eq("Receiver",UserHelper.uEmail ))
                                 .Add(NHibernate.Criterion.Restrictions.Eq("Topic", Topic));
                crit2.SetMaxResults(50);
                IList<MessageInbox> messagesin2 = crit2.List<MessageInbox>();
                return messagesin2;
            }
            catch (Exception e)
            { throw e; }   
        }

        // 获取收件箱所有邮件
        public IList<MessageInbox> GetAllMessageInbox()
        {
            NHibernateHelper helper = new NHibernateHelper();
            ISession session = helper.GetSession();
            try
            {
                ICriteria crit3 = session.CreateCriteria(typeof(Email.Domain.Entities.MessageInbox))
                              .Add(NHibernate.Criterion.Restrictions.Eq( "Receiver",UserHelper.uEmail));
                              
                crit3.SetMaxResults(50);
                IList<MessageInbox>  messagesin3= crit3.List<MessageInbox>();
                return messagesin3;
            }
            catch (Exception e)
            { throw e; }   
        }

       

        // 添加收件箱信息
         public void AddMessageInbox(MessageInbox message)
        {
            NHibernateHelper helper = new NHibernateHelper();
            ISession Session = helper.GetSession();          
            if (message != null)
               Session.Save(message);          
        }
      /*  public void AddMessageInbox(Object messageinbox)
        {
            NHibernateHelper helper = new NHibernateHelper();
            ISession Session = helper.GetSession();
            ITransaction transaction = Session.BeginTransaction();
            try 
            { 
                Session.Save(messageinbox); 
                transaction.Commit(); 
            }
            catch (Exception e)
            { 
                transaction.Rollback();
                throw e;
            }
            finally 
            { 
                Session.Close(); 
            }
        }*/
    }
}
