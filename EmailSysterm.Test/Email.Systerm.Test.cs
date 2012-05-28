using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using NHibernate.Cfg;
using EmailSysterm.Data;
using EmailSysterm.Domain.Entities;

namespace EmailSysterm.Test
{
    [TestClass]
    public class EmailTest
    {
        private UserData _user;
        private ISession _session;
        [TestMethod]
        public void TestUser()
        {
            
            _session = new NHibernateHelper().GetSession();
            _user = new UserData(_session);
           // var tempUser = new User{ UserName = "Lily",Email = "349751642@qq.com",  Password = "45682" };
           // _user.CreateUser(tempUser);
            User userInfo = _user.GetUserByEmail("940194901@qq.com");
            string userName = userInfo.UserName;   
            Assert.AreEqual("Tomy", userName);
           
            string password = userInfo.Password ;
            Assert.AreEqual("123456",password);
        }
      
    }
}
