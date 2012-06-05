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
            dataGridView1.DataSource = linkmandata.GetAllLinkman();
        }

         // 添加联系人
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 )
            {
                MessageBox.Show("必要信息不能为空");
            }
            else
            {
                Email.Domain.Entities.Linkman linkman = new Email.Domain.Entities.Linkman();
                linkman.Receiver = textBox1.Text;
                linkman.Sender = UserHelper.uEmail;                
                string id = UserHelper.uEmail+textBox1.Text;
                linkman.LinkmanId = id;
                Email.Domain.Entities.Linkman testlinkmans ;
                testlinkmans = linkmandata.GetLinkmanByLinkmanId(id);
                if (testlinkmans != null)
                    MessageBox.Show("该邮箱已是你的联系人");
                else
                {
                    linkmandata.AddLinkman(linkman);
                    Email.Domain.Entities.Linkman testlinkmans1 = linkmandata.GetLinkmanByLinkmanId(id);
                    if (testlinkmans1 != null)
                      MessageBox.Show("添加成功！");
                    // Linkman linkmanpage = new Linkman();                
                    // linkmanpage.Show();
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
    }
}
