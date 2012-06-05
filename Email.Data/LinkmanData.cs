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
        public IList GetLinkmanByReceiver(string Sender,string Receiver)
        { 
            NHibernateHelper helper = new NHibernateHelper();
            ISession session = helper.GetSession();
           return session.CreateCriteria(typeof(Email.Domain.Entities.Linkman))
               .Add(NHibernate.Criterion.Restrictions.Eq("Sender", Sender) & NHibernate.Criterion.Restrictions.Eq("Receiver", Receiver))
               .List();
        }

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
    }
}
