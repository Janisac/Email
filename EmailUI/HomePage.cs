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
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sendMessage sendmessage = new sendMessage();
            sendmessage.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageOutbox messageoutbox = new MessageOutbox();
            messageoutbox.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageInbox messageinbox = new MessageInbox();
            messageinbox.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Linkman linkman = new Linkman();
            linkman.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Logging logging = new Logging();
            logging.Show();
        }
    }
}
