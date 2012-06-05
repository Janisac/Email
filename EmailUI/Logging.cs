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
        //private Email.Data.UserHelper helper;
        private Email.Data.UserData userdata;
        //private System.Collections.IList clist;
        public Logging()
        {
            InitializeComponent();
        }

        // 注册
        private void button1_Click(object sender, EventArgs e)
        {
              //UserHelper.uEmail = textBox1.Text.Trim();
            //helper.uEmail = textBox1.Text.Trim();
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0)
            {
                MessageBox.Show("必要信息不能为空");
            }
            else
            {
                Email.Domain.Entities.User user = new Email.Domain.Entities.User();
                user.Email = textBox1.Text;
                user.PassWord = textBox2.Text;
                userdata = new Email.Data.UserData();
                 Email.Domain.Entities.User user1 = userdata.GetUserByEmail(textBox1.Text);
                if(user1 != null)
                    MessageBox.Show("该邮箱已注册");
                else
                {
                    userdata = new Email.Data.UserData();
                    userdata.AddUser(user);
                    Email.Domain.Entities.User users = userdata.GetUserByEmail(textBox1.Text);
                    if (users != null)
                    {
                        MessageBox.Show("注册成功！");
                        Logging logging = new Logging();
                        logging.Close();
                    }
                   // HomePage homepage = new HomePage();
                   // homepage.Show();
                }
               
            }
        }

        // 登录
        private void button2_Click(object sender, EventArgs e)
        {          
            userdata = new Email.Data.UserData();
           
            string email =  textBox1.Text;
            string pwd = textBox2.Text;
           
            Email.Domain.Entities.User usertest = userdata.GetUserByEmail(textBox1.Text);
            if (usertest == null || usertest.PassWord != textBox2.Text)
            {
                MessageBox.Show("用户名或密码与错误，无法登录。", "登录错误");
            }
            else
            {
                UserHelper.uEmail = textBox1.Text;
                HomePage homepage = new HomePage();
                homepage.Show();
                this.Hide();
            }

        }

        private void Logging_Load(object sender, EventArgs e)
        {

        }

       
    }
}
