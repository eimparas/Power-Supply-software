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
    public partial class INST_IP : Form
    {
        public INST_IP()
        {
            InitializeComponent();
        }

        private void Dhcp_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = !dhcp.Checked;
        }

        private void INST_IP_Load(object sender, EventArgs e)
        {

        }

        private void key(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                Debug.WriteLine("ok");
                SendKeys.SendWait("{TAB}");
            }

            

        }
    }
}
