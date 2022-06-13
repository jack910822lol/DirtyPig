using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DirtyPig
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void gameStart_Click(object sender, EventArgs e)
        {
            string username = name.Text;
            string Ip = ip.Text;
            string Port = port.Text;
            Form2 f = new Form2(username, Ip, Int16.Parse(Port));
            f.FormClosing += new FormClosingEventHandler(f2_FormClosing);
            this.Visible = false;
            f.Visible = true;
        }
        void f2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }
    }
}
