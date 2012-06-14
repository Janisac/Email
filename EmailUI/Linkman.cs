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
    public partial class Linkman : Form
    {
        private Email.Data.LinkmanData linkmandata;
        // private System.Collections.IList clist;
        public Linkman()
        {
            InitializeComponent();
            linkmandata = new Email.Data.LinkmanData();
            dataGridView1.ReadOnly = true;
        }

        // 清空
        private void Empty()
        {
            dataGridView1.DataSource = null;
        }

        // 显示联系人列表
        private void button1_Click(object sender, EventArgs e)
        {
            if (linkmandata.GetAllLinkman().Count == 0)
                MessageBox.Show("对不起，您还没有联系人！");
            else
                dataGridView1.DataSource = linkmandata.GetAllLinkman();
        }

         // 添加联系人
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("必要信息不能为空");
            }
            else
            {
                Email.Domain.Entities.Linkman linkman = new Email.Domain.Entities.Linkman();
                Email.Domain.Entities.User user = new Email.Domain.Entities.User();
                linkman.Receiver = textBox1.Text;
                linkman.Sender = UserHelper.uEmail;
                string id1 = textBox1.Text;
                user.Email = id1;
                string id2 = UserHelper.uEmail + textBox1.Text;
                linkman.LinkmanId = id2;
                Email.Domain.Entities.User testuser;
                Email.Data.UserData userdata = new UserData();
                testuser = userdata.GetUserByEmail(id1);
                Email.Domain.Entities.Linkman testlinkmans;
                testlinkmans = linkmandata.GetLinkmanByLinkmanId(id2);
                if (testuser == null)
                {
                    MessageBox.Show("不存在该账号！");

                }
                else
                {
                    if (testlinkmans != null)
                    { MessageBox.Show("该邮箱已是你的联系人"); }
                    else
                    {
                        linkmandata.AddLinkman(linkman);
                        Email.Domain.Entities.Linkman testlinkmans1 = linkmandata.GetLinkmanByLinkmanId(id2);
                        if (testlinkmans1 != null)
                            MessageBox.Show("添加成功！");
                    }
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

        // 清空
        private void button4_Click(object sender, EventArgs e)
        {
            Empty();
        }

        private void Linkman_Load(object sender, EventArgs e)
        {

        }

        // 删除单个联系人
        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
                MessageBox.Show("请输入联系人邮箱！");
            else
            {
                if (linkmandata.GetLinkmanByReceiver(Email.Data.UserHelper.uEmail, textBox2.Text).Count == 0)
                {
                    MessageBox.Show("该帐号不是你的联系人！");
                    textBox2.Clear();
                }
                else
                {
                    if (MessageBox.Show("确定删除？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        linkmandata.DeleteLinkmanByReceiver(textBox2.Text, Email.Data.UserHelper.uEmail);
                        if (linkmandata.GetLinkmanByReceiver(Email.Data.UserHelper.uEmail, textBox2.Text).Count == 0)
                            MessageBox.Show("删除联系人成功！");
                        else
                            MessageBox.Show("删除联系人失败！");
                        textBox2.Clear();
                    }
                }
            }
        }

        // 删除所有联系人
        private void button6_Click(object sender, EventArgs e)
        {
            if (linkmandata.GetAllLinkman().Count == 0)
            {
                MessageBox.Show("没有联系人，无需删除！");
            }
            else
            {
                if(MessageBox.Show("确定删除？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    linkmandata.DeleteAllLinkman();
                    if (linkmandata.GetAllLinkman().Count == 0)
                        MessageBox.Show("删除联系人成功!");
                    else
                        MessageBox.Show("删除联系人失败！");
                }
            }
        }

        //  添加联系人后，刷新显示所有联系人
        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = linkmandata.GetAllLinkman();
        }

        //  删除单个联系人后，刷新显示所有联系人
        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = linkmandata.GetAllLinkman();
        }

        //  删除所有联系人后，刷新显示联系人
        private void button9_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = linkmandata.GetAllLinkman();
        }

               
    }
}
