using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Power_Supply_DashBoard
{
    public partial class SCPI_terminal : Form
    {
        public SCPI_terminal()
        {
            InitializeComponent();
            
        }

        private void keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return) { enter_return(); }
        }

        void enter_return()
        {
            Returntb.Text += CMD.Text + "\r\n";
            CMD.Text = "";
        }

        private void Send_Click(object sender, EventArgs e)
        {
            enter_return();
        }

        private void load(object sender, EventArgs e)
        {
            SendKeys.SendWait("{TAB}");
        }
    }
}
