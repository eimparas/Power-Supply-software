using System;
using System.IO;
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
        FolderBrowserDialog save = new FolderBrowserDialog();
        string _DocumentLocation = "";
        string _ourDir;
        public networksetup()
        {
            InitializeComponent();            
        }

        private void networksetup_Load(object sender, EventArgs e)
        {
            _ourDir = Properties.Settings.Default.DataPath;//retrive the lastUsed Path
            save.SelectedPath = _ourDir;//set the folderPicker StartPoint
            ip1.Text = Convert.ToString(Properties.Settings.Default.IP1);
            ip2.Text = Convert.ToString(Properties.Settings.Default.IP2);
            ip3.Text = Convert.ToString(Properties.Settings.Default.IP3);
            ip4.Text = Convert.ToString(Properties.Settings.Default.IP4);//retrive the lastUsed IP
            SaveTxtBox.Text = _ourDir;
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

            Properties.Settings.Default.Hostname = _ip;
            Properties.Settings.Default.IP1 = Convert.ToInt16(ip1.Text);
            Properties.Settings.Default.IP2 = Convert.ToInt16(ip2.Text);
            Properties.Settings.Default.IP3 = Convert.ToInt16(ip3.Text);
            Properties.Settings.Default.IP4 = Convert.ToInt16(ip4.Text);//Store the lastUsed IP
            Properties.Settings.Default.DataPath = _ourDir;//Store the last used Dir

            Properties.Settings.Default.Save();
            try
            {
                //main._SCPI = new SocketManagement(_ip, 5025);
                //main._SCPI.connect();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                string caption = "Error Detected in Establishing Connection";
                MessageBoxButtons buttons = MessageBoxButtons.AbortRetryIgnore;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
                if (result == DialogResult.Abort)
                {
                    // Closes the parent form.
                    this.Close();
                }
                
                if(result == DialogResult.Retry)
                {
                    Connect();
                }
            }
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

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var result = save.ShowDialog();
            if (result == DialogResult.OK)
            {
                _ourDir = save.SelectedPath;
                Properties.Settings.Default.DataPath = _ourDir;//save the app's workdir to the config                 
                save.SelectedPath = _ourDir;//set the folderPicker to the new  StartPoint
                SaveTxtBox.Text = Properties.Settings.Default.DataPath;//Write the path to the textbox from the config
                Properties.Settings.Default.Save();//Save the config
                Debug.WriteLine(Properties.Settings.Default.DataPath);
            }
        }
    }
}
