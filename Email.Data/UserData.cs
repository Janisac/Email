using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using Email.Domain.Entities;

namespace Email.Data
{
   public class UserData
    {
       public UserData()
       { }


       //根据邮箱查询用户（status）
       public IList GetUserByEmail(string Email)
       {
           NHibernateHelper helper = new NHibernateHelper();
           ISession session = helper.GetSession();

           return session.CreateCriteria(typeof(Email.Domain.Entities.User))
               .Add(NHibernate.Criterion.Restrictions.Eq("Email", Email))
               .List();
       } 
       /*public User GetUserByEmail(String Email)
        {
            NHibernateHelper helper = new NHibernateHelper();
            ISession Session = helper.GetSession();
            return Session.Get<User>(Email);
        }*/
        /*public void CreateUser(User userInfo)
        {
            NHibernateHelper helper = new NHibernateHelper();
            ISession Session = helper.GetSession();
            Session.Save(userInfo);
            //Session.Flush( );
            Session.Close();
        }*/

       public bool AddUser(User user) 
        {
            NHibernateHelper helper = new NHibernateHelper();
            ISession Session = helper.GetSession();
            ITransaction transaction = Session.BeginTransaction();
            try { Session.Save(user); transaction.Commit(); return true; } 
            catch (Exception e)
            { transaction.Rollback(); return false; }
            finally { Session.Close(); }
        }

       public bool UpdateUser(User userInfo)
       {
           NHibernateHelper helper = new NHibernateHelper();
           ISession Session = helper.GetSession();
           ITransaction transaction = Session.BeginTransaction();
           try{  Session.Update(userInfo); transaction.Commit();   return true;   }
           catch (Exception e) { transaction.Rollback();  return false;       }
           finally {  Session.Close(); }
       }

       public bool DeleteUser(User userInfo)
        {
            NHibernateHelper helper = new NHibernateHelper();
            ISession Session = helper.GetSession();
            ITransaction transaction = Session.BeginTransaction();
            try { Session.Delete(userInfo); transaction.Commit(); return true; }
            catch (Exception e) { transaction.Rollback(); return false; }
            finally { Session.Close(); }
        }

       

        
    }
}
