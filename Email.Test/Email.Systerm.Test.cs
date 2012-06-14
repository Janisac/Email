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
        //private ISession _session;
        /* private Email.Data.UserData userdata = new UserData();
         private Email.Data.MessageInboxData messageinboxdata = new MessageInboxData();
         private Email.Data.MessageOutboxData messageoutboxdata = new MessageOutboxData();
         private Email.Data.LinkmanData linkmandata = new LinkmanData();
         Linkman linkman = new Linkman(); 
         MessageInbox messageinbox = new MessageInbox();
        
         //测试连通性
          [TestMethod]
        public void UserTest()
         {
             //_session = new NHibernateHelper().GetSession();
             userdata = new Email.Data.UserData();
             User userInfo = new User();
             userInfo = userdata.GetUserByEmail("34zxc1642@qq.com");
              if (userInfo!=null) 
              Assert.AreEqual("45682", userInfo.PassWord);
         }

        //注册新用户
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

         //修改密码
         [TestMethod]
         public void UpdateUserTest()
         {
             UserData userdata = new Email.Data.UserData();
             User testusers = userdata.GetUserByEmail("lily@qq.com");
             testusers.PassWord ="126";
             userdata.UpdateUser(testusers);
             testusers = userdata.GetUserByEmail("lily@qq.com");
             Assert.AreEqual("126",testusers.PassWord);
         }

         //删除用户
         [TestMethod]
         public void DeleteUserTest()
         {
             userdata = new Email.Data.UserData();
             User testusers = userdata.GetUserByEmail("969903420");
             userdata.DeleteUser(testusers);
             testusers = userdata.GetUserByEmail("969903420");
             Assert.IsNull(testusers);
         }

         //添加联系人
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

         //删除单个联系人
         [TestMethod]
         public void DeleteLinkmanByReceiverTest()
         {
             linkmandata = new Email.Data.LinkmanData();
             string sender = "123@qq.com";
             string receiver = "456@qq.com";           
             linkmandata.DeleteLinkmanByReceiver(sender,receiver);
              IList<Linkman> testlinkmans = linkmandata.GetLinkmanByReceiver( sender,receiver);
              Assert.AreEqual(0, testlinkmans.Count); 
         }

         //删除所有联系人
          [TestMethod]
         public void DeleteAllLinkmanTest()
         {
             linkmandata = new Email.Data.LinkmanData();
             UserHelper.uEmail = "123@qq.com";            
             linkmandata.DeleteAllLinkman();
             IList<Linkman> testlinkmans = linkmandata.GetAllLinkman();
             Assert.AreEqual(0, testlinkmans.Count);
         }

         //添加一封邮件到收件箱
         [TestMethod]
         public void AddMessageInboxTest()
          {
             string id;
             MessageInbox messageinbox = new MessageInbox();
             MessageInboxData messageinboxdata = new MessageInboxData();
             id=messageinbox.MessageinId = DateTime.Now.ToString();
             messageinbox.Sender ="123@qq.com";
             messageinbox.Receiver ="456@qq.com";
             messageinbox.Topic = "wenhao";
             messageinbox.Content = "nihaoma?";
             messageinboxdata.AddMessageInbox(messageinbox);
             MessageInbox messageinboxtest = messageinboxdata.GetMessageInboxById(id);
             Assert.IsNotNull(messageinboxtest);
         }

         //按发件人删除收件箱的邮件
         [TestMethod]
         public void DeleteMessageInboxBySenderTest()
         {
             MessageInbox messageinbox = new MessageInbox();
             MessageInboxData messageinboxdata = new MessageInboxData();
             string sender = "123@qq.com";
             string receiver = "456@qq.com";
             messageinboxdata.DeleteMessageInboxBySender(sender,receiver);
             IList<MessageInbox> testmessageinbox = messageinboxdata.GetMessageInboxBySender(sender);
             Assert.AreEqual(0, testmessageinbox.Count);
         }

         //按主题删除收件箱的邮件
         [TestMethod]
         public void DeleteMessageInboxByTopicTest()
         {
             MessageInbox messageinbox = new MessageInbox();
             MessageInboxData messageinboxdata = new MessageInboxData();
             string receiver = "123@qq.com";
             UserHelper.uEmail = receiver;
             string topic = "12";
             messageinboxdata.DeleteMessageInboxByTopic(topic,receiver);
             IList<MessageInbox> testmessageinbox = messageinboxdata.GetMessageInboxByTopic( topic);
             Assert.AreEqual(0, testmessageinbox.Count);
         }

         //删除所有收件箱的邮件
         [TestMethod]
         public void DeleteAllMessageInboxTest()
         {            
             MessageInboxData messageinboxdata = new MessageInboxData();
             UserHelper.uEmail = "123@qq.com";
             messageinboxdata.DeleteAllMessageInbox();
             IList<MessageInbox> testmessageinbox = messageinboxdata.GetAllMessageInbox();
             Assert.AreEqual(0, testmessageinbox.Count);
         }

         //添加一封邮件到发件箱
         [TestMethod]
         public void AddMessageOutboxTest()
         {
             string id;
             MessageOutbox messageOutbox = new MessageOutbox();
             MessageOutboxData messageOutboxdata = new MessageOutboxData();
             id = messageOutbox.MessageoutId = DateTime.Now.ToString();
             messageOutbox.Sender = "123@qq.com";
             messageOutbox.Receiver = "456@qq.com";
             messageOutbox.Topic = "wenhao";
             messageOutbox.Content = "nihaoma?";
             messageOutboxdata.AddMessageOutbox(messageOutbox);
             MessageOutbox messageinboxtest = messageOutboxdata.GetMessageOutboxById(id);
             Assert.IsNotNull(messageinboxtest);
         }

         //按发件人删除发件箱的邮件
         [TestMethod]
         public void DeleteMessageOutboxBySenderTest()
         {
             MessageOutbox messageoutbox = new MessageOutbox();
             MessageOutboxData messageoutboxdata = new MessageOutboxData();
             string sender = "123@qq.com";
             string receiver = "456@qq.com";
             messageoutboxdata.DeleteMessageOutboxByReceiver(sender, receiver);
             IList<MessageOutbox> testmessageinbox = messageoutboxdata.GetMessageOutboxByReceiver(sender);
             Assert.AreEqual(0, testmessageinbox.Count);
         }

         //按主题删除发件箱的邮件
         [TestMethod]
         public void DeleteMessageOutboxByTopicTest()
         {
             MessageOutbox messageoutbox = new MessageOutbox();
             MessageOutboxData messageoutboxdata = new MessageOutboxData();
             string sender = "mary@qq.com";
             //UserHelper.uEmail = sender;
             string topic = "12";
             messageoutboxdata.DeleteMessageOutboxByTopic(sender, topic);
             IList<MessageOutbox> testmessageoutbox = messageoutboxdata.GetMessageOutboxByTopic(topic);
             Assert.AreEqual(0, testmessageoutbox.Count);
         }

         //删除所有发件箱的邮件
         [TestMethod]
         public void DeleteAllMessageOutboxTest()
         {
             MessageOutboxData messageoutboxdata = new MessageOutboxData();
             UserHelper.uEmail = "lg@qq.com";
             messageoutboxdata.DeleteAllMessageOutbox();
             IList<MessageOutbox> testmessageoutbox = messageoutboxdata.GetAllMessageOutbox();
             Assert.AreEqual(0, testmessageoutbox.Count);
         }*/

     }
 
}