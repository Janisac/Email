using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Email.Data;
using Email.Domain.Entities;

namespace EmailUI
{
    public partial class PIManager : Form
    {
        private Email.Data.UserData userdata;
        private Email.Data.LinkmanData linkmandata;
        private Email.Data.MessageInboxData messageinboxdata;
        private Email.Data.MessageOutboxData messageoutboxdata;
        public PIManager()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void PIManager_Load(object sender, EventArgs e)
        {

        }

        // 修改密码
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                MessageBox.Show("必要信息不能为空！");
            else 
            {
                UserData userdata1 = new UserData();
                User user = userdata1.GetUserByEmail(UserHelper.uEmail);
                if (textBox1.Text != user.PassWord)
                    MessageBox.Show("密码输入错误！");
                else if (textBox2.Text != textBox3.Text)
                    MessageBox.Show("新密码的两次输入不一致！");
                else
                {
                    if (textBox1.Text == textBox2.Text)
                        MessageBox.Show("新密码与旧密码相同，请重新输入！");
                    else
                    {
                        user.Email = UserHelper.uEmail;
                        user.PassWord = textBox2.Text;
                        userdata1.UpdateUser(user);
                        if (user.PassWord == textBox3.Text)
                        {
                            MessageBox.Show("密码修改成功，请重新登录！");
                            Logging logging = new Logging();
                            logging.Show();
                            this.Hide();
                        }
                        else
                            MessageBox.Show("密码修改失败！");
                    }
                }
            }
        }

        //  注销账号
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
                MessageBox.Show("请输入密码");
            else
            {
                UserData userdata3 = new UserData();
                MessageOutboxData messageoutboxdata = new MessageOutboxData();
                MessageInboxData messageinboxdata = new MessageInboxData();
                LinkmanData linkmandata = new LinkmanData();
                User user = userdata3.GetUserByEmail(UserHelper.uEmail);
                if (textBox4.Text != user.PassWord)
                {
                    MessageBox.Show("密码错误，请重新输入！");
                    textBox4.Clear();
                }
                else
                {
                    //User user = new User();
                    //user.Email = UserHelper.uEmail;
                    //user.PassWord = textBox4.Text;
                    userdata3.DeleteUser(user);
                    linkmandata.DeleteAllLinkman();
                    messageinboxdata.DeleteAllMessageInbox();
                    messageoutboxdata.DeleteAllMessageOutbox();
                    //UserData userdata3 = new UserData();
                    User user1 = userdata3.GetUserByEmail(UserHelper.uEmail);
                    if (user1 == null & messageinboxdata.GetAllMessageInbox().Count == 0 & messageoutboxdata.GetAllMessageOutbox().Count == 0 & linkmandata.GetAllLinkman().Count == 0)
                    {
                        MessageBox.Show("注销用户成功，并退出系统！");
                        textBox4.Clear();
                        this.Hide();
                        Logging logging = new Logging();
                        logging.Show();
                    }
                    else
                        MessageBox.Show("注销用户失败");
                }
            }
        }

        // 返回
        private void button3_Click(object sender, EventArgs e)
        {
            HomePage homepage = new HomePage();
            homepage.Show();
            this.Hide();
        }
    }
}
