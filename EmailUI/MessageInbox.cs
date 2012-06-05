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
    public partial class MessageInbox : Form
    {
        private Email.Data.MessageInboxData messageinboxdata;
        //private System.Collections.IList<MessageInbox> clist;
        //IList<MessageInbox> clist;
        public MessageInbox()
        {
            InitializeComponent();
            messageinboxdata = new Email.Data.MessageInboxData();
            dataGridView1.ReadOnly = true;
        }

        // 清空
        private void Empty()
        {
            dataGridView1.DataSource = null;
        }

        // 按发件人查询
        private void button1_Click(object sender, EventArgs e)
        {
           // String Sender = textBox1.Text;
            dataGridView1.DataSource = messageinboxdata.GetMessageInboxBySender(textBox1.Text);
        }

        // 按主题查询
        private void button2_Click(object sender, EventArgs e)
        {
            //String Topic = textBox2.Text;
            dataGridView1.DataSource = messageinboxdata.GetMessageInboxByTopic(textBox2.Text);
        }

        // 返回
        private void button3_Click(object sender, EventArgs e)
        {
            HomePage homepage = new HomePage();
            homepage.Show();
            this.Hide();
        }
        // 查询所有收件箱的邮件
        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = messageinboxdata.GetAllMessageInbox();
        }

        // 清空
        private void button5_Click(object sender, EventArgs e)
        {
            Empty();
        }

        private void MessageInbox_Load(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
