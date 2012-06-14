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
            if (messageinboxdata.GetMessageInboxBySender(textBox1.Text).Count == 0)
                MessageBox.Show("没有符合条件的邮件！");
            else
                dataGridView1.DataSource = messageinboxdata.GetMessageInboxBySender(textBox1.Text);
        }

        // 按主题查询
        private void button2_Click(object sender, EventArgs e)
        {
            if (messageinboxdata.GetMessageInboxByTopic(textBox2.Text).Count == 0)
                MessageBox.Show("没有符合条件的邮件！");
            else
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
            if (messageinboxdata.GetAllMessageInbox().Count == 0)            
                MessageBox.Show("收件箱中没有邮件！");
            else
                dataGridView1.DataSource = messageinboxdata.GetAllMessageInbox();
        }

        // 清空
        private void button5_Click(object sender, EventArgs e)
        {
            Empty();
        }
        
       
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void MessageInbox_Load(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }      
        

        private void label2_Click(object sender, EventArgs e)
        {

        }

        //  按发件人删除邮件
        private void button6_Click(object sender, EventArgs e)
        {        
            if (textBox3.Text == "")
                MessageBox.Show("请输入发件人邮箱！");
            else if (messageinboxdata.GetMessageInboxBySender(textBox3.Text).Count == 0)
                MessageBox.Show("没有符合条件的邮件！");
            else
            {
                if (MessageBox.Show("确定删除？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    messageinboxdata.DeleteMessageInboxBySender(textBox3.Text, Email.Data.UserHelper.uEmail);
                    if (messageinboxdata.GetMessageInboxBySender(textBox3.Text).Count == 0)
                        MessageBox.Show("删除信息成功！");
                    else
                        MessageBox.Show("删除信息失败！");
                    textBox3.Clear();
                }
            }
        }

        //  按主题删除
        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
                MessageBox.Show("请输入主题");
            else if (messageinboxdata.GetMessageInboxByTopic(textBox4.Text).Count == 0)
                MessageBox.Show("没有符合条件的邮件！");
            else
            {
                if (MessageBox.Show("确定删除？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    messageinboxdata.DeleteMessageInboxByTopic(textBox4.Text, Email.Data.UserHelper.uEmail);
                    if (messageinboxdata.GetMessageInboxByTopic(textBox4.Text).Count == 0)
                        MessageBox.Show("删除信息成功!");
                    else
                        MessageBox.Show("删除信息失败！");
                    textBox4.Clear();
                }
            }
        }

        //  删除所有邮件
        private void button8_Click(object sender, EventArgs e)
        {
            if (messageinboxdata.GetAllMessageInbox().Count == 0)
            {
                MessageBox.Show("收件箱中没有邮件！");
            }
            else
            {
                if (MessageBox.Show("确定删除？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    messageinboxdata.DeleteAllMessageInbox();
                    if (messageinboxdata.GetAllMessageInbox().Count == 0)
                        MessageBox.Show("删除信息成功!");
                    else
                        MessageBox.Show("删除信息失败！");
                }
            }
        }

        // 按发件人删除信息后，刷新显示收件箱信息
        private void button9_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = messageinboxdata.GetAllMessageInbox();
        }

        // 按主题删除信息后，刷新显示收件箱信息
        private void button10_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = messageinboxdata.GetAllMessageInbox();
        }

        // 删除所有信息后，刷新显示收件箱信息
        private void button11_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = messageinboxdata.GetAllMessageInbox();
        }    
    }
}
