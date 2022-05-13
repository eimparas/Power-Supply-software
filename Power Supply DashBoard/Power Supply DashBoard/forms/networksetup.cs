using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SPD3303X_E;

namespace Power_Supply_DashBoard
{
    public partial class networksetup : Form
    {
        public networksetup()
        {
            InitializeComponent();
            
        }

        private void networksetup_Load(object sender, EventArgs e)
        {

        }

        private void key(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar =='.')
            {
                Debug.WriteLine("ok");
                SendKeys.SendWait("{TAB}");
            }
            
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void conect_Click(object sender, EventArgs e)
        {
            Connect();
        }
        void Connect()
        {
            string _ip = ip1.Text + '.' + ip2.Text+'.'+ ip3.Text+ip4.Text;
            /*main main = new main();
            main.connect(_ip);
            Thread.Sleep(100);*/
            main._SCPI = new SocketManagement(_ip, 5025);
            main._SCPI.connect();
            main.Chart1Timer.Start();
            main.Chart2Timer.Start();
            this.Close();
        }
        private void keyDn(object sender, KeyEventArgs e)
        {
            Debug.WriteLine(e.KeyCode);
            if (e.KeyCode == Keys.Return)
            {
                Connect();
            }
        }

    }
}
