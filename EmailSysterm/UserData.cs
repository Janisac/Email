using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using EmailSysterm.Domain.Entities;

namespace EmailSysterm.Data
{
   public  class UserData
    {
        protected ISession Session { get; set; }
        public UserData(ISession session)
        {
            Session = session;
        }
        public void CreateUser(User userInfo)
        {
            Session.Save(userInfo);
            //Session.Flush( );
            Session.Close();
        }

       public bool InsertUser(User userInfo) 
        {             
            ITransaction transaction = Session.BeginTransaction();
            try { Session.Save(userInfo); transaction.Commit(); return true; } 
            catch (Exception e)
            { transaction.Rollback(); return false; }
            finally { Session.Close(); }
        }

       public bool UpdateUser(User userInfo)
       {
           ITransaction transaction = Session.BeginTransaction();
           try{  Session.Update(userInfo); transaction.Commit();   return true;   }
           catch (Exception e) { transaction.Rollback();  return false;       }
           finally {  Session.Close(); }
       }

       public bool DeleteUser(User userInfo)
        {
            ITransaction transaction = Session.BeginTransaction();
            try { Session.Delete(userInfo); transaction.Commit(); return true; }
            catch (Exception e) { transaction.Rollback(); return false; }
            finally { Session.Close(); }
        }

        public User GetUserByEmail(String Email)
        {
            return Session.Get<User>(Email);
        }

        
    }
}
