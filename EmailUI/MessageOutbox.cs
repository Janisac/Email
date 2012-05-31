using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EmailUI
{
    public partial class MessageOutbox : Form
    {
        private Email.Data.MessageOutboxData messageoutboxdata;
        private System.Collections.IList clist;
        public MessageOutbox()
        {
            InitializeComponent();
            messageoutboxdata = new Email.Data.MessageOutboxData();
            dataGridView1.ReadOnly = true;
        }

        //  清空
         private void Empty()
        {
            dataGridView1.DataSource = null;
        }

         // 按收件人查询
         private void button1_Click(object sender, EventArgs e)
         {
             String Receiver = textBox1.Text;
             clist = messageoutboxdata.GetMessageOutboxByReceiver(Receiver);
         }

         // 按主题查询
         private void button2_Click(object sender, EventArgs e)
         {
             String Topic = textBox2.Text;
             clist = messageoutboxdata.GetMessageOutboxByTopic(Topic);
          }

         // 查询所有发件箱的邮件
         private void button3_Click(object sender, EventArgs e)
         {
             dataGridView1.DataSource = messageoutboxdata.GetAllMessageOutbox();
         }

         // 返回
         private void button4_Click(object sender, EventArgs e)
         {
             HomePage homepage = new HomePage();
             homepage.Show();
         }

         // 清空
         private void button5_Click(object sender, EventArgs e)
         {
             Empty();
         }
    }
}
