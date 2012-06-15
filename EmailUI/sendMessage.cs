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
                Email.Domain.Entities.MessageInbox messageinbox = new Email.Domain.Entities.MessageInbox();
                Email.Domain.Entities.MessageOutbox messageoutbox = new Email.Domain.Entities.MessageOutbox();
                Email.Data.MessageInboxData messageinboxdata = new Email.Data.MessageInboxData();
                Email.Data.MessageOutboxData messageoutboxdata = new Email.Data.MessageOutboxData();

                Email.Domain.Entities.Linkman linkman = new Email.Domain.Entities.Linkman();
                string[] arr = textBox1.Text.Split(';');
                int number = arr.Length;

                int num,  j, k = 0;
                string[] arr1 = new string[number];
                string string1 = "", string2 = "";
                for (num = 0; num < number; num++)
                {
                    IList<Email.Domain.Entities.Linkman> lm;
                    linkmandata = new Email.Data.LinkmanData();
                    lm = linkmandata.GetLinkmanByReceiver(UserHelper.uEmail, arr[num]);
                    if (lm.Count == 0)
                        string1 = string1 + arr[num] + ";";
                    else
                    {
                        string2 = string2 + arr[num] + ";";
                        arr1[k++] = arr[num];
                    }
                }
                
                messageinbox.Sender = messageoutbox.Sender = UserHelper.uEmail;
                messageinbox.Topic = messageoutbox.Topic = textBox2.Text;
                messageinbox.Content = messageoutbox.Content = "收件人：" + string2 + "\n" + textBox3.Text;

                if(string1 != null)
                    MessageBox.Show(string1 + "不是你的联系人，请于好友界面添加！");
                if(k != 0)
                {
                    for (j = 0; j < k; j++)
                    {
                        messageinbox.MessageinId = messageoutbox.MessageoutId = DateTime.Now.ToString();
                        messageinbox.Receiver = messageoutbox.Receiver = arr1[j];
                        messageoutboxdata.AddMessageOutbox(messageoutbox);
                        messageinboxdata.AddMessageInbox(messageinbox);
                    }
                    MessageBox.Show("已成功将邮件发送给" + string2 );
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
