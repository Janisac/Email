using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Email.Data;

namespace EmailUI
{
    public partial class sendMessage : Form
    {
        private Email.Data.LinkmanData linkmandata;
       // private Email.Data.MessageInboxData messageinboxdata;
       // private Email.Data.MessageOutboxData messageoutboxdata;
       // private System.Collections.IList clist;
        public sendMessage()
        {
            InitializeComponent();
        }

        // 发送邮件
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                MessageBox.Show("不能含有空信息！");
            else
            {
                Email.Domain.Entities.Linkman linkman = new Email.Domain.Entities.Linkman();
                linkman.Receiver = textBox1.Text;
                Email.Domain.Entities.MessageInbox messageinbox = new Email.Domain.Entities.MessageInbox();
                Email.Domain.Entities.MessageOutbox messageoutbox = new Email.Domain.Entities.MessageOutbox();
                Email.Data.MessageInboxData messageinboxdata = new Email.Data.MessageInboxData();
                Email.Data.MessageOutboxData messageoutboxdata = new Email.Data.MessageOutboxData();

                messageinbox.MessageinId = messageoutbox.MessageoutId = DateTime.Now.ToString();
                messageinbox.Sender = messageoutbox.Sender = UserHelper.uEmail;
                messageinbox.Receiver = messageoutbox.Receiver = textBox1.Text;
                messageinbox.Topic = messageoutbox.Topic = textBox2.Text;
                messageinbox.Content = messageoutbox.Content = textBox3.Text;

                IList<Email.Domain.Entities.Linkman> lm;
                // Email.Domain.Entities.Linkman linkmans ;
                linkmandata = new Email.Data.LinkmanData();
                lm = linkmandata.GetLinkmanByReceiver(UserHelper.uEmail, textBox1.Text);
                if (lm.Count == 0)
                {
                    MessageBox.Show("此收件人不是你的联系人，请于好友界面添加！");
                    this.Hide();
                    HomePage homepage = new HomePage();
                    homepage.Show();

                }
                else
                {
                    messageinboxdata.AddMessageInbox(messageinbox);
                    messageoutboxdata.AddMessageOutbox(messageoutbox);
                    MessageBox.Show("邮件发送成功！");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                }
            }
            
        }

        // 返回
        private void button2_Click(object sender, EventArgs e)
        {
            HomePage homepage = new HomePage();
            homepage.Show();
            this.Hide();
        }

        private void sendMessage_Load(object sender, EventArgs e)
        {

        }        
    }
}
