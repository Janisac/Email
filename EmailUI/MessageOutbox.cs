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
        //private System.Collections.IList clist;
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
             //String Receiver = textBox1.Text;
             dataGridView1.DataSource = messageoutboxdata.GetMessageOutboxByReceiver(textBox1.Text);
         }

         // 按主题查询
         private void button2_Click(object sender, EventArgs e)
         {
            // String Topic = textBox2.Text;
             dataGridView1.DataSource = messageoutboxdata.GetMessageOutboxByTopic(textBox2.Text);
             
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
             this.Hide();
         }

         // 清空
         private void button5_Click(object sender, EventArgs e)
         {
             Empty();
         }

         private void MessageOutbox_Load(object sender, EventArgs e)
         {

         }
    }
}
