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
            Session.Flush( );
        }
        public User GetUserByEmail(String Email)
        {
            return Session.Get<User>(Email);
        }
    }
}
