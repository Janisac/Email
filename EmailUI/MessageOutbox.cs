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
             if (messageoutboxdata.GetMessageOutboxByReceiver(textBox1.Text).Count == 0)
                 MessageBox.Show("没有符合条件的邮件！");
             else
                 dataGridView1.DataSource = messageoutboxdata.GetMessageOutboxByReceiver(textBox1.Text);
         }

         // 按主题查询
         private void button2_Click(object sender, EventArgs e)
         {
             if (messageoutboxdata.GetMessageOutboxByTopic(textBox2.Text).Count == 0)
                 MessageBox.Show("没有符合条件的邮件！");
             else
                 dataGridView1.DataSource = messageoutboxdata.GetMessageOutboxByTopic(textBox2.Text);             
          }

         // 查询所有发件箱的邮件
         private void button3_Click(object sender, EventArgs e)
         {
             if (messageoutboxdata.GetAllMessageOutbox().Count == 0)
                 MessageBox.Show("收件箱中没有邮件！");
             else
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

        //  按收件人删除邮件
         private void button6_Click(object sender, EventArgs e)
         {
             if (textBox3.Text == "")
                 MessageBox.Show("请输入收件人邮箱！");
             else if (messageoutboxdata.GetMessageOutboxByReceiver(textBox3.Text).Count == 0)
                 MessageBox.Show("没有符合条件的邮件！");
             else
             {
                 if (MessageBox.Show("确定删除？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                 {
                     messageoutboxdata.DeleteMessageOutboxByReceiver(Email.Data.UserHelper.uEmail, textBox3.Text);
                     if (messageoutboxdata.GetMessageOutboxByReceiver(textBox3.Text).Count == 0)
                         MessageBox.Show("删除信息成功！");
                     else
                         MessageBox.Show("删除信息失败！");
                     textBox3.Clear();
                 }
             }
         }


         private void button7_Click(object sender, EventArgs e)
         {
             if (textBox4.Text == "")
                 MessageBox.Show("请输入主题！");
             else if (messageoutboxdata.GetMessageOutboxByTopic(textBox4.Text).Count == 0)
                 MessageBox.Show("没有符合条件的邮件！");
             else
             {
                 if (MessageBox.Show("确定删除？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                 {
                     messageoutboxdata.DeleteMessageOutboxByTopic(Email.Data.UserHelper.uEmail, textBox4.Text);
                     if (messageoutboxdata.GetMessageOutboxByTopic(textBox4.Text).Count == 0)
                         MessageBox.Show("删除信息成功！");
                     else
                         MessageBox.Show("删除信息失败！");
                     textBox3.Clear();
                 }
             }
         }

        //  删除所有邮件
         private void button8_Click(object sender, EventArgs e)
         {
             if (messageoutboxdata.GetAllMessageOutbox().Count == 0)
             {
                 MessageBox.Show("发件箱中没有邮件！");
             }
             else
             {
                 if (MessageBox.Show("确定删除？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                 {
                     messageoutboxdata.DeleteAllMessageOutbox();
                     if (messageoutboxdata.GetAllMessageOutbox().Count == 0)
                         MessageBox.Show("删除信息成功!");
                     else
                         MessageBox.Show("删除信息失败！");
                 }
             }
         }

         private void textBox3_TextChanged(object sender, EventArgs e)
         {

         }

        // 按收件人删除邮件后，刷新显示发件箱信息
         private void button9_Click(object sender, EventArgs e)
         {
             dataGridView1.DataSource = messageoutboxdata.GetAllMessageOutbox();
         }

        //  按主题删除邮件后，刷新显示发件箱信息
         private void button10_Click(object sender, EventArgs e)
         {
             dataGridView1.DataSource = messageoutboxdata.GetAllMessageOutbox();
         }

        //  删除所有邮件后，刷新显示发件箱信息
         private void button11_Click(object sender, EventArgs e)
         {
             dataGridView1.DataSource = messageoutboxdata.GetAllMessageOutbox();
         }
    }
}
