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
            //save.Title = "path to dataloging Directory";
            //save.Filter = "Directory | directory";
           
        }

        private void networksetup_Load(object sender, EventArgs e)
        {
            _DocumentLocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
             
            _ourDir = _DocumentLocation + "\\PSU Dashboard";
            Debug.WriteLine(_ourDir);
            if (!Directory.Exists(_ourDir))
            {
                Directory.CreateDirectory(_ourDir);
            }//check to see if the Directory used by the app is created in the system , if not creates it. 
            SaveTxtBox.Text = _ourDir;
            save.SelectedPath = _ourDir;
            
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
            try
            {
                 main._SCPI = new SocketManagement(_ip, 5025);
                 main._SCPI.connect();
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
                SaveTxtBox.Text = _ourDir;
            }
        }
    }
}
