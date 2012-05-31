using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using EmailSysterm.Domain.Entities;
namespace EmailSysterm
{
    public class InBoxData
    {
        protected ISession Session { get; set; }
        public InBoxData(ISession session)
        {
            Session = session;
        }
        public void CreateInBox(InBox emailInfo)
        {
            
            Session.Save(emailInfo);
            //Session.Flush();
            Session.Close();
        }
       
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
        public InBox GetInBoxByAddressor(String Addressor)
        {
            return Session.Get<InBox>(Addressor);
        }
       
    }
}
