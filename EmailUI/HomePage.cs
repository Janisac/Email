using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Email.Data;

namespace EmailUI
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
            //toolStripStatusLabel1.Text = UserHelper.uEmail;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sendMessage sendmessage = new sendMessage();
            sendmessage.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageOutbox messageoutbox = new MessageOutbox();
            messageoutbox.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageInbox messageinbox = new MessageInbox();
            messageinbox.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Linkman linkman = new Linkman();
            linkman.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Logging logging = new Logging();
            logging.Show();
            this.Hide();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            PIManager pimanager = new PIManager();
            pimanager.Show();
            this.Hide();
        }      
    }
}
