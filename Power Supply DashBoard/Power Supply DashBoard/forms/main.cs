using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;
using System.Net.Sockets;
using System.Net;
using System.Configuration;
using System.Timers;


namespace Power_Supply_DashBoard
{
    public partial class main : Form
    {
        Thread comsThread = new Thread(ScPi_coms);
        System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer
        {    
            Interval = 100    
        };


        int GridlinesOffset = 0;
        int x;
        int x2;
        static IPAddress iPAddress;
        static string CH1Volt="0";//output voltage
        static string CH1Amps;//output current
        static string CH1Vset;//set voltage
        static string CH1Aset;//set current 

        static bool CH1onOfflg = false;

        static bool CH1Set = false;
        static string CH1Vstrans;

        static bool NotInitialied = true;
        static bool comIsStarted = false;
        static bool intFlg = false;
        static bool SerFlg = false;
        static bool ParFlg = false;
        bool state = true;
        bool RS1state = true;
        bool RS2state = true;
        const int bufferSize = 1024;
        const int port = 5025;
        static byte[] bytes = new byte[1024];
        // constant messages 
        static byte[] meaVch1 = Encoding.ASCII.GetBytes("MEASure:VOLTage? CH1");
        static byte[] Vch1 = Encoding.ASCII.GetBytes("CH1:VOLTage?");
        static byte[] OUTch1ON = Encoding.ASCII.GetBytes("OUTPut CH1,ON");
        static byte[] OUTch1OFF = Encoding.ASCII.GetBytes("OUTPut CH1,OFF");
        static byte[] IDN = Encoding.ASCII.GetBytes("*idn?");

 
        public void connect(string ip)
        {     
            try
            {
                iPAddress = IPAddress.Parse(ip);
                comsThread.IsBackground = true;//sets the ip address 
                comsThread.Start();// starts the communication thread

                while (NotInitialied)
                {
                    //wait
                    Debug.WriteLine("waiting");
                }//whait for the initalazation to complete then proccide to eneble the ui update
                Chart1Roll.Enabled = true;               
                RUN_STP_1.Checked = true;

                timer1.Enabled = true;
                timer1.Tick += new System.EventHandler(CH1fp_Tick);
                // and initiete the update timers for ui operation 
            }
            catch(Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }//this funcion is execued when connect is clicked from net_setup
         

        public main()
        {
            
            InitializeComponent();
            for (int i = 0; i < 60; i++)
            {
                chart1.Series["Voltage"].Points.AddY(0);
                chart1.Series["current"].Points.AddY(0);
                chart2.Series["Voltage"].Points.AddY(0);
                chart2.Series["current"].Points.AddY(0);              
            }//chart y`y axis setup            
           
        }

   

        static void ScPi_coms()//coms thread
        {
            try
            {               
                Socket SCPI = new Socket(iPAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint remoteEP = new IPEndPoint(iPAddress, port);//create socket and endpoint 
                Debug.WriteLine(remoteEP);              

                SCPI.Connect(remoteEP);//connect to socket 
                SCPI.Send(IDN);
                int idnbyte = SCPI.Receive(bytes);
                string idn_resp = Encoding.ASCII.GetString(bytes, 0, idnbyte); //and identify the instrument 


                MessageBox.Show(idn_resp, "instrument connected at : ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                while (true)
                {
                    Thread.Sleep(800);


                   // data acquisition
                    SCPI.Send(meaVch1);
                    CH1Volt = Encoding.ASCII.GetString(bytes, 0, SCPI.Receive(bytes));//Vout_CH1
                    

                    SCPI.Send(Vch1);
                    CH1Vset = Encoding.ASCII.GetString(bytes, 0, SCPI.Receive(bytes));//Vset_CH1

                    NotInitialied = false;
                    //instrument control 

                    if (CH1onOfflg == true)
                    {
                        Debug.WriteLine("CH1on");                      
                        SCPI.Send(OUTch1ON);
                    }
                    else
                    {
                        Debug.WriteLine("CH1of");
                        SCPI.Send(OUTch1OFF);
                    }

                    if (CH1Set == true)// requested to change the voltage on CH1
                    {
                        CH1Set = false;//reset the flag 
                        string buffer = "CH1:VOLTage " + CH1Vstrans;//setup the buffer 
                        SCPI.Send(Encoding.ASCII.GetBytes(buffer));//execute the cmd
                        Debug.WriteLine("ch1set : " + CH1Set);

                    }

                    if (intFlg == true)//recuested to change the output mode 
                    {
                        intFlg = false;//reset the flag
                        string buffer = "OUTPut:TRACK 0";//setup the buffer
                        SCPI.Send(Encoding.ASCII.GetBytes(buffer));//execute the cmd
                    }

                    if (SerFlg == true)
                    {
                        SerFlg = false;
                        string buffer = "OUTPut:TRACK 1";
                        SCPI.Send(Encoding.ASCII.GetBytes(buffer));
                    }

                    if (ParFlg == true)
                    {
                        ParFlg = false;
                        string buffer = "OUTPut:TRACK 2";
                        SCPI.Send(Encoding.ASCII.GetBytes(buffer));
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
        }


        private void Chart1Roll_Tick(object sender, EventArgs e)
        {

                GridlinesOffset++;
                x++;
            Debug.WriteLine(CH1Volt);
                chart1.Series["Voltage"].Points.AddY(/*10*Math.Sin(2 + x)*/ Convert.ToDecimal(CH1Volt));//data point 
                chart1.Series["Voltage"].Points.RemoveAt(0);
                chart1.Series["current"].Points.AddY(Math.Sin(2 + x));//data point 
                chart1.Series["current"].Points.RemoveAt(0);
                chart1.ChartAreas[0].AxisX.MajorGrid.IntervalOffset = -GridlinesOffset;
                chart1.ChartAreas[1].AxisX.MajorGrid.IntervalOffset = -GridlinesOffset;
                GridlinesOffset %= (int)chart1.ChartAreas[0].AxisX.MajorGrid.Interval;
                GridlinesOffset %= (int)chart1.ChartAreas[1].AxisX.MajorGrid.Interval;
        
        }//chart 1
        private void Chart2Roll_Tick(object sender, EventArgs e)
        {
            x2++;
            chart2.Series["Voltage"].Points.AddY(10 + 1 * Math.Cos(55 + x2));//data point 
            chart2.Series["Voltage"].Points.RemoveAt(0);
            chart2.Series["current"].Points.AddY(2 + Math.Sin(x2));//data point 
            chart2.Series["current"].Points.RemoveAt(0);
            chart2.ChartAreas[0].AxisX.MajorGrid.IntervalOffset = -GridlinesOffset;
            chart2.ChartAreas[1].AxisX.MajorGrid.IntervalOffset = -GridlinesOffset;
            GridlinesOffset %= (int)chart2.ChartAreas[0].AxisX.MajorGrid.Interval;
            GridlinesOffset %= (int)chart2.ChartAreas[1].AxisX.MajorGrid.Interval;
        }//chart 2      

      

        private void RUN_STP_1_CheckedChanged(object sender, EventArgs e)
        {
            RS1state = RUN_STP_1.Checked;
            if(RS1state== true)
            {
                Chart1Roll.Start();

            }else
            {
                Chart1Roll.Stop();
            }
        }

        private void RUN_STP_2_CheckedChanged(object sender, EventArgs e)
        {
            RS2state = RUN_STP_2.Checked;  
            if (RS2state == true)
            {
                Chart2Roll.Start();

            }else
            {
                Chart2Roll.Stop();
            }
        }

        private void M1_Click(object sender, EventArgs e)
        {
            if (mem_save_check.Checked == true)
            {
                var mes = MessageBox.Show("are you sure that you want to save?","Warning", MessageBoxButtons.OKCancel);
                string message = Convert.ToString(mes);
                if (message == "OK")
                {
                    Debug.WriteLine("save current setings to psu memory ");
                }
                mem_save_check.Checked = false;
            }
            else
            {
                Debug.WriteLine("send memory to psu");
            }
        }

        private void M2_Click(object sender, EventArgs e)
        {
           
        }



        private void Int_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (Int_RadioButton.Checked)
            {
                Debug.WriteLine("int");
                intFlg = true;
            }
        }

        private void Ser_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (Ser_radioButton.Checked)
            {
                Debug.WriteLine("ser");
                SerFlg = true;
            }

        }

        private void Par_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                Debug.WriteLine("par");
                ParFlg = true;
            }
        }

        private void ChartFotm_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;//when psu enters paralel serial monitor 
                                          //this mode will apply. the data being desplyed deped on the mode (int par ) 
        }

        private void CH1onOFF_CheckedChanged(object sender, EventArgs e)
        {
            CH1onOfflg = CH1onOFF.Checked;//control instrumet output 
            
        }

        
        private void CH1set_Click(object sender, EventArgs e)
        {
            CH1Set = true;
            CH1Vstrans = CH1vText.Text;
        }
        private void terminalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SCPI_terminal SCPI_TER = new SCPI_terminal();
            SCPI_TER.Show();
        }

        private void NetworkSetingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            networksetup netset = new networksetup();
            netset.ShowDialog();
        }

        private void InstrumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            INST_IP isntset = new INST_IP();
            isntset.ShowDialog();
        }

        private void DatalogingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart chartdialog = new chart();
            chartdialog.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            
        }

        public  void CH1fp_Tick(object sender, EventArgs e)
        {
            CH1vText.Text = "hello";
            
        }
    }
}