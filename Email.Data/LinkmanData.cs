using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using NHibernate;
using Email.Domain.Entities;

namespace Email.Data
{
    public class LinkmanData
    {
        public LinkmanData()
        { }

        // 获取所有联系人信息
        public IList<Linkman> GetAllLinkman()
        {
            NHibernateHelper helper = new NHibernateHelper();
            ISession session = helper.GetSession();            
           // return session.CreateCriteria(typeof(LinkmanData));
            try
            {
                ICriteria crit = session.CreateCriteria(typeof(Linkman))
                    .Add(NHibernate.Criterion.Restrictions.Eq("Sender", UserHelper.uEmail));
                   
                crit.SetMaxResults(50);
                IList<Linkman> linkmans = crit.List<Linkman>();
                return linkmans;
            }
            catch (Exception e)
            { throw e; }         
        }
        
        // 添加联系人
        public void AddLinkman(Linkman linkman)
        {
            NHibernateHelper helper = new NHibernateHelper();
            ISession Session = helper.GetSession();          
            if (linkman != null)
               Session.Save(linkman);          
        }

        /*public void AddLinkman(Object  linkman)
        {
            NHibernateHelper helper = new NHibernateHelper();
            ISession Session = helper.GetSession();
            ITransaction transaction = Session.BeginTransaction();
            try 
            { 
                Session.Save(linkman); 
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

        // 按收件人查看联系人
        public IList<Linkman> GetLinkmanByReceiver(string Sender,string Receiver)
        { 
            NHibernateHelper helper = new NHibernateHelper();
            ISession session = helper.GetSession();
            try
            {
                ICriteria crit = session.CreateCriteria(typeof(Linkman))
                    .Add(NHibernate.Criterion.Restrictions.Eq("Sender", Sender) & NHibernate.Criterion.Restrictions.Eq("Receiver", Receiver));

                crit.SetMaxResults(50);
                IList<Linkman> linkmans = crit.List<Linkman>();
                return linkmans;
            }
            catch (Exception e)
            { throw e; }  
           
        }

        // 按主题查询联系人
        public Email.Domain.Entities.Linkman GetLinkmanByLinkmanId(string linkmanid)
        {
            NHibernateHelper helper = new NHibernateHelper();
            ISession session = helper.GetSession();
            return session.Get<Email.Domain.Entities.Linkman>(linkmanid);
           
        } 

        // 查看发件人信息
       

       /* public IList<LinkmanData> GetlinkmanBySender(string email)
        {
            NHibernateHelper helper = new NHibernateHelper();
            ISession session = helper.GetSession();
            return session.Get<Email.Domain.Entities.LinkmanData>(email);
        }*/
        public Email.Domain.Entities.Linkman GetlinkmanBySender(string Email)
        {
            NHibernateHelper helper = new NHibernateHelper();
            ISession session = helper.GetSession();
            return session.Get<Email.Domain.Entities.Linkman>(Email);
            
        }

        // 删除单个联系人
        public void DeleteLinkmanByReceiver(string receiver, string sender)
        {
            NHibernateHelper helper = new NHibernateHelper();
            ISession session = helper.GetSession();
            try
            {
                ICriteria crit1 = session.CreateCriteria(typeof(Email.Domain.Entities.Linkman))
                              .Add(NHibernate.Criterion.Restrictions.Eq("Sender", sender))
                              .Add(NHibernate.Criterion.Restrictions.Eq("Receiver", receiver));

                crit1.SetMaxResults(50);
                IList<Linkman> linkman1 = crit1.List<Linkman>();
                foreach (Linkman linkman in linkman1)
                {
                    session.Delete(linkman);
                    session.Flush();
                }
            }
            catch (Exception e)
            { throw e; }   
        }

        // 删除所有联系人
        public void DeleteAllLinkman()
        {
           // LinkmanData linkmandata = new LinkmanData();
            NHibernateHelper helper = new NHibernateHelper();
            ISession session = helper.GetSession();
            try
            {
                ICriteria crit2 = session.CreateCriteria(typeof(Email.Domain.Entities.Linkman))
                              .Add(NHibernate.Criterion.Restrictions.Eq("Sender",UserHelper.uEmail));

                crit2.SetMaxResults(50);
                IList<Linkman> linkman2 = crit2.List<Linkman>();
                foreach (Linkman linkmans in linkman2)
                {
                    session.Delete(linkmans);
                    session.Flush();
                }
            }
            catch (Exception e)
            { throw e; }
        }
    }
}
