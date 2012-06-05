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
       public Email.Domain.Entities.User GetUserByEmail(string Email)
       {
           NHibernateHelper helper = new NHibernateHelper();
           ISession session = helper.GetSession();
           return session.Get<Email.Domain.Entities.User>(Email);
          /* return session1.CreateCriteria(typeof(Email.Domain.Entities.User))
               .Add(NHibernate.Criterion.Restrictions.Eq("Email", Email))
               .List();*/
       } 
      
       // 添加用户
       public void AddUser(User user)
       {
           NHibernateHelper helper = new NHibernateHelper();
           ISession Session = helper.GetSession();
           string useremail;
           if(user != null)
            useremail = (string)Session.Save(user);
          // return useremail;
       }

      /* public void  AddUser(Object  user) 
        {
            NHibernateHelper helper = new NHibernateHelper();
            ISession session = helper.GetSession();
            ITransaction transaction = session.BeginTransaction();
            try
            {
                session.Save(user);
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                 throw e;
            }
            finally
            {
                session.Close();
            }
        }*/
       public void UpdateUser(Object user)
       {
           NHibernateHelper helper = new NHibernateHelper();
           ISession session = helper.GetSession();
           ITransaction transaction = session.BeginTransaction();
           try
           {
               session.Update(user);
               transaction.Commit();
           }
           catch (Exception e )
           {
               transaction.Rollback();
               throw  e;
           }
           finally
           {
               session.Close();
           }
       }
       public void DeleteUser(Object user)
       {
           NHibernateHelper helper = new NHibernateHelper();
           ISession session = helper.GetSession();
           ITransaction transaction = session.BeginTransaction();
           try
           {
               session.Delete(user);
               transaction.Commit();
           }
           catch (Exception e)
           {
               transaction.Rollback();
               throw e;
           }
           finally
           {
               session.Close();
           }
       }
     
    }
}
