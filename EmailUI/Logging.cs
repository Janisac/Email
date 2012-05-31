using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Email.Data;
using Email.Domain.Entities;

namespace EmailUI
{
    public partial class Logging : Form
    {
        private Email.Data.UserData userdata;
        private System.Collections.IList clist;
        public Logging()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 | textBox2.Text.Length == 0)
            {
                MessageBox.Show("必要信息不能为空");
            }
            Email.Domain.Entities.User user = new Email.Domain.Entities.User();
            user.Email = textBox1.Text;
            user.PassWord = textBox2.Text;
            userdata.AddUser(user);
            IList users = userdata.GetUserByEmail(textBox1.Text);
            if (users.Count == 0)
            {
                MessageBox.Show("注册成功！");
                HomePage homepage = new HomePage();
                homepage.Show();
            }
            else 
            {
                MessageBox.Show("该邮箱已注册");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string pwd = textBox2.Text;

            userdata = new Email.Data.UserData();
            clist = userdata.GetUserByEmail(email);

            if (clist.Count == 0)
            {
                MessageBox.Show("用户名或密码与错误，无法登录。", "登录错误");
                //Logging logging = new Logging();
                //logging.Show();
            }
            else
            {
                HomePage homepage = new HomePage();
                homepage.Show();
            }

        }

       
    }
}
