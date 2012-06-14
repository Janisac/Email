using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using NHibernate;
using Email.Domain.Entities;

namespace Email.Data
{
    public  class MessageOutboxData
    {
        public MessageOutboxData()
        { }

        // 按收件人查询
        public IList<MessageOutbox> GetMessageOutboxByReceiver(String Receiver)
        {
            NHibernateHelper helper = new NHibernateHelper();
            ISession session = helper.GetSession();
            try
            {
                ICriteria crit1 = session.CreateCriteria(typeof(Email.Domain.Entities.MessageOutbox))
                                 .Add(NHibernate.Criterion.Restrictions.Eq("Sender",UserHelper.uEmail ))
                                 .Add(NHibernate.Criterion.Restrictions.Eq("Receiver", Receiver));
                crit1.SetMaxResults(50);
                IList<MessageOutbox> messagesout1 = crit1.List<MessageOutbox>();
                return messagesout1;
            }
            catch (Exception e)
            { throw e; }  
        }

        // 按主题查询
        public IList<MessageOutbox> GetMessageOutboxByTopic(String Topic)
        {
            NHibernateHelper helper = new NHibernateHelper();
            ISession session = helper.GetSession();          
            try
            {
                ICriteria crit2 = session.CreateCriteria(typeof(Email.Domain.Entities.MessageOutbox))
                                .Add(NHibernate.Criterion.Restrictions.Eq("Sender",UserHelper.uEmail ))
                                .Add(NHibernate.Criterion.Restrictions.Eq("Topic", Topic));
                crit2.SetMaxResults(50);
                IList<MessageOutbox> messagesout2 = crit2.List<MessageOutbox>();
                return messagesout2;
            }
            catch (Exception e)
            { throw e; }  
        }

        // 获取收件箱所有邮件
        public IList<MessageOutbox> GetAllMessageOutbox()
        {
            NHibernateHelper helper = new NHibernateHelper();
            ISession session = helper.GetSession();
            try
            {
                ICriteria crit3 = session.CreateCriteria(typeof(Email.Domain.Entities.MessageOutbox))
                              .Add(NHibernate.Criterion.Restrictions.Eq("Sender",UserHelper.uEmail ));
                crit3.SetMaxResults(50);
                IList<MessageOutbox> messagesout3 = crit3.List<MessageOutbox>();
                return messagesout3;
            }
            catch (Exception e)
            { throw e; }   
        }

        // 添加发件箱信息
        public void AddMessageOutbox(MessageOutbox message)
        {
            NHibernateHelper helper = new NHibernateHelper();
            ISession Session = helper.GetSession();
            if (message != null)
                Session.Save(message);
        }
       /* public void AddMessageOutbox(Object messageoutbox)
        {
            NHibernateHelper helper = new NHibernateHelper();
            ISession Session = helper.GetSession();
            ITransaction transaction = Session.BeginTransaction();
            try 
            { 
                Session.Save(messageoutbox); 
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

        // 按收件人删除邮件
        public void DeleteMessageOutboxByReceiver(String sender, String receiver)
        {
            NHibernateHelper helper = new NHibernateHelper();
            ISession session = helper.GetSession();
            try
            {
                ICriteria crit4 = session.CreateCriteria(typeof(Email.Domain.Entities.MessageOutbox))
                              .Add(NHibernate.Criterion.Restrictions.Eq("Sender", sender))
                              .Add(NHibernate.Criterion.Restrictions.Eq("Receiver", receiver));
                crit4.SetMaxResults(50);
                IList<MessageOutbox> messagesin4 = crit4.List<MessageOutbox>();
                foreach (MessageOutbox message in messagesin4)
                {
                    session.Delete(message);
                    session.Flush();
                }
            }
            catch (Exception e)
            { throw e; }
        }

        // 按主题删除邮件
        public void DeleteMessageOutboxByTopic(String sender, String topic)
        {
            NHibernateHelper helper = new NHibernateHelper();
            ISession session = helper.GetSession();
            try
            {
                ICriteria crit5 = session.CreateCriteria(typeof(Email.Domain.Entities.MessageOutbox))
                              .Add(NHibernate.Criterion.Restrictions.Eq("Sender", sender))
                              .Add(NHibernate.Criterion.Restrictions.Eq("Topic", topic));
                crit5.SetMaxResults(50);
                IList<MessageOutbox> messagesin5 = crit5.List<MessageOutbox>();
                foreach (MessageOutbox message in messagesin5)
                {
                    session.Delete(message);
                    session.Flush();
                }
            }
            catch (Exception e)
            { throw e; }
        }

        //  删除所有邮件
        public void DeleteAllMessageOutbox()
        {
            //MessageOutboxData lessageoutboxdata = new MessageOutboxData();
            NHibernateHelper helper = new NHibernateHelper();
            ISession session = helper.GetSession();
            try
            {
                ICriteria crit6 = session.CreateCriteria(typeof(Email.Domain.Entities.MessageOutbox))
                              .Add(NHibernate.Criterion.Restrictions.Eq("Sender", UserHelper.uEmail));

                crit6.SetMaxResults(50);
                IList<MessageOutbox> messagesin6 = crit6.List<MessageOutbox>();
                foreach (MessageOutbox message in messagesin6)
                {
                    session.Delete(message);
                    session.Flush();
                }
            }
            catch (Exception e)
            { throw e; }
        }

       
         // 按id查询发件箱
        public Email.Domain.Entities.MessageOutbox GetMessageOutboxById(string messageoutboxid)
        {
            NHibernateHelper helper = new NHibernateHelper();
            ISession session = helper.GetSession();
            return session.Get<Email.Domain.Entities.MessageOutbox>(messageoutboxid);

        }        
    }
}

