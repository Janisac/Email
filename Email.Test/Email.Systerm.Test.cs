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
       // private MessageInboxData _inbox;
       // private UserData _user;
        private ISession _session;
        private Email.Data.UserData userdata;
       // private Email.Data.MessageInboxData messageinboxdata;
       //  private Email.Data.MessageOutboxData messageoutboxdata;
        private Email.Data.LinkmanData linkmandata;
       // private System.Collections.IList clist;

         [TestMethod]
       public void UserTest()
        {
            _session = new NHibernateHelper().GetSession();
            userdata = new Email.Data.UserData();
            User userInfo = new User();
            userInfo = userdata.GetUserByEmail("34zxc1642@qq.com");
             if (userInfo!=null) 
             Assert.AreEqual("45682", userInfo.PassWord);
        }

       /* [TestMethod]
        public void AddUserTest()
        {
            Email.Domain.Entities.User users = null;
            users = userdata.GetUserByEmail("34zxc1642@qq.com");
            Assert.IsNull(users);
            /* _session = new NHibernateHelper().GetSession();
             _user = new UserData(_session);
             var tempUser = new User{ Email = "34zxc1642@qq.com",  Password = "45682" };
             _user.CreateUser(tempUser);
        }
      */
        [TestMethod]
        public void AddUserTest()
        {
            var users = new User();
            users.Email = "meng@qq.com";
            users.PassWord = "123456";
            userdata = new Email.Data.UserData();
            User testusers ; //= userdata.GetUserByEmail("lily@qq.com"); 
            userdata.AddUser(users);            
            testusers = userdata.GetUserByEmail("meng@qq.com");
            Assert.IsNotNull(testusers);               
        }

        [TestMethod]
        public void UpdateUserTest()
        {
            userdata = new Email.Data.UserData();
            User testusers = userdata.GetUserByEmail("lily@qq.com");
            testusers.PassWord ="126";
            userdata.UpdateUser(testusers);
            testusers = userdata.GetUserByEmail("lily@qq.com");
            Assert.AreEqual("126",testusers.PassWord);
        }

        [TestMethod]
        public void DeleteUserTest()
        {
            userdata = new Email.Data.UserData();
            User testusers = userdata.GetUserByEmail("969903420");
            userdata.DeleteUser(testusers);
            testusers = userdata.GetUserByEmail("969903420");
            Assert.IsNull(testusers);
        }

        [TestMethod]
        public void AddLinkmanTest()
        {
            var linkmans = new Linkman();
            linkmans.LinkmanId = "to@qq.comlily@qq.com";
            linkmans.Sender = "to@qq.com";
            linkmans.Receiver = "lily@qq.com";
            linkmandata = new Email.Data.LinkmanData();
            Linkman testlinkmans ; 
            linkmandata.AddLinkman(linkmans);
            testlinkmans = linkmandata.GetlinkmanBySender("lily@qq.com");
            Assert.IsNotNull(testlinkmans);
        }

       /* [TestMethod]
        public void GetAllLinkmanTest()
        {
            IList<LinkmanData> 
        }
        
        /*[TestMethod]
        public void InsertUserTest()
        {
            _session = new NHibernateHelper().GetSession();
            userdata = new Email.Data.UserData();
          // User userInfo = new User();
            var tempUser = new User {  Email = "34zxc1642@qq.com", PassWord = "45682" };
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
       /*  [TestMethod]
       public void GetUserByEmailTest()
        {
            Email.Domain.Entities.User users = userdata.GetUserByEmail("34zxc1642@qq.com");
            Assert.IsNotNull(users);
            //Assert.AreEqual(1, users.);
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
