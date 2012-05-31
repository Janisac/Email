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
        private InBoxData _inbox;
        private UserData _user;
        private ISession _session;

        /*[TestMethod]
        public void UserTest()
        {
            _session = new NHibernateHelper().GetSession();
            _user = new UserData(_session);
            User userInfo = _user.GetUserByEmail("940194901@qq.com");
            string userName = userInfo.UserName;
            Assert.AreEqual("Tomy", userName);
            string password = userInfo.Password;
            Assert.AreEqual("123456", password);
        }*/
        /*
        [TestMethod]
        public void CreateUserTest()
        {            
            _session = new NHibernateHelper().GetSession();
            _user = new UserData(_session);
            var tempUser = new User{ UserName = "Lily",Email = "34zxc1642@qq.com",  Password = "45682" };
            _user.CreateUser(tempUser);
        }
        
        [TestMethod]
        public void InsertUserTest()
        {
            _session = new NHibernateHelper().GetSession();
            _user = new UserData(_session);
            var tempUser = new User { UserName = "Mary", Email = "34zxc1642@qq.com", Password = "45682" };
            _user.InsertUser(tempUser);
        }
        [TestMethod]
        public void UpdateUserTest()
        {
            _session = new NHibernateHelper().GetSession();
            _user = new UserData(_session);
            var tempUser = new User { UserName = "Linda", Email = "34zxc1642@qq.com", Password = "12345682" };
            _user.UpdateUser(tempUser);
        }*/

        [TestMethod]
        public void DeleteUserTest()
        {
            _session = new NHibernateHelper().GetSession();
            _user = new UserData(_session);
            User userInfo = _user.GetUserByEmail("34zxc1642@qq.com");
            _user.DeleteUser(userInfo);
        }
        [TestMethod]
        public void CreateInBoxTest()
        {
            _session = new NHibernateHelper().GetSession();
            _inbox = new InBoxData(_session);
            var tempInBox = new InBox { Addressor = "940194901@qq.com", Addressee = "meili@163.com", Title = "Hi" ,Content=""};
            _inbox.CreateInBox(tempInBox);
        }
        [TestMethod]
        public void InBoxTest()
        {
            _session = new NHibernateHelper().GetSession();
            _inbox = new InBoxData(_session);
            InBox inboxInfo = _inbox.GetInBoxByAddressor("940194901@qq.com");
            string Addressee = inboxInfo.Addressee;
            Assert.AreEqual("meili@163.com", Addressee);
        }

    }
}
