using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using NHibernate.Cfg;
using Email.Data;
using Email.Domain.Entities;
using System.Collections;

namespace Email.Test
{
    [TestClass]
    public class EmailTest
    {
        private MessageInboxData _inbox;
        private UserData _user;
        private ISession _session;
        private Email.Data.UserData userdata;
        private Email.Data.MessageInboxData messageinboxdata;
        private Email.Data.MessageOutboxData messageoutboxdata;
        private Email.Data.LinkmanData linkmandata;
        private System.Collections.IList clist;

        /*[TestMethod]
        public void UserTest()
        {
            _session = new NHibernateHelper().GetSession();
            _user = new UserData(_session);
            User userInfo = _user.GetUserByEmail("940194901@qq.com");
            string password = userInfo.Password;
            Assert.AreEqual("123456", password);
        }*/
        
        [TestMethod]
        public void AddUserTest()
        {
            IList users = userdata.GetUserByEmail("34zxc1642@qq.com");
            Assert.AreEqual(0, users.Count);
           /* _session = new NHibernateHelper().GetSession();
            _user = new UserData(_session);
            var tempUser = new User{ Email = "34zxc1642@qq.com",  Password = "45682" };
            _user.CreateUser(tempUser);*/
        }
        
        /*[TestMethod]
        public void InsertUserTest()
        {
            _session = new NHibernateHelper().GetSession();
            _user = new UserData(_session);
            var tempUser = new User {  Email = "34zxc1642@qq.com", Password = "45682" };
            _user.InsertUser(tempUser);
        }
        [TestMethod]
        public void UpdateUserTest()
        {
            _session = new NHibernateHelper().GetSession();
            _user = new UserData(_session);
            var tempUser = new User {  Email = "34zxc1642@qq.com", Password = "12345682" };
            _user.UpdateUser(tempUser);
        }

        [TestMethod]
        public void DeleteUserTest()
        {
            _session = new NHibernateHelper().GetSession();
            _user = new UserData(_session);
            User userInfo = _user.GetUserByEmail("34zxc1642@qq.com");
            _user.DeleteUser(userInfo);
        }*/
        [TestMethod]
        public void GetUserByEmailTest()
        {
            IList users = userdata.GetUserByEmail("34zxc1642@qq.com");
            Assert.AreEqual(1, users.Count);
           // _session = new NHibernateHelper().GetSession();
           // Isession _user = new UserData(_session);
           // var tempUser = new User { Email = "34zxc1642@qq.com", PassWord = "45682" };
           // _user.CreateUser(tempUser);
        }
        /*[TestMethod]
        public void CreateMessageInboxTest()
        {
            _session = new NHibernateHelper().GetSession();
            _inbox = new MessageInboxData(_session);
            var tempInBox = new MessageInbox { Sender = "940194901@qq.com", Receiver = "meili@163.com", Topic = "Hi" ,Content="   "};
            _inbox.CreateMessageInbox(tempInBox);
        }*/
       /* [TestMethod]
        public void MessageInboxTest()
        {
            _session = new NHibernateHelper().GetSession();
            _inbox = new MessageInboxData(_session);
            MessageInbox inboxInfo = _inbox.GetMessageInboxBySender("940194901@qq.com");
            string Receiver = inboxInfo.Receiver;
            Assert.AreEqual("meili@163.com", Receiver);
        }*/

    }
}
