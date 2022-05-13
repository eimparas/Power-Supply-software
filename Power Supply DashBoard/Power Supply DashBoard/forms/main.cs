using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;
using System.Net.Sockets;
using System.Net;
using System.Configuration;
using System.Timers;
using SPD3303X_E;
using Timer = System.Windows.Forms.Timer;

namespace Power_Supply_DashBoard
{
    public partial class main : Form
    {      
        int GridlinesOffset = 0;       
        //System.Windows.Forms.Timer TcpSCPI = new System.Windows.Forms.Timer()
        //{
        //    Interval=100
        //};
        bool CH1onOfflg = false;
        bool RS1state = true;
        bool RS2state = true;
        const int port = 5025;
        byte[] bytes = new byte[1024];
        public static SocketManagement _SCPI;
        public static Timer Chart1Timer, Chart2Timer;
 

        public main()
        {          
            InitializeComponent();
            //TcpSCPI.Tick += TcpSCPI_Tick;
            Chart1Timer = Chart1Roll;
            Chart2Timer = Chart2Roll;
            for (int i = 0; i < 60; i++)
            {
                chart1.Series["Voltage"].Points.AddY(0);
                chart1.Series["current"].Points.AddY(0);
                chart2.Series["Voltage"].Points.AddY(0);
                chart2.Series["current"].Points.AddY(0);
            }//chart Y axis setup            

        }

        private void TcpSCPI_Tick(object sender, EventArgs e)
        {
            //try
            //{
                
            //    SCPI.Send(IDN);
            //    int idnbyte = SCPI.Receive(bytes);
            //    string idn_resp = Encoding.ASCII.GetString(bytes, 0, idnbyte); //and identify the instrument 
            //    Debug.WriteLine(idn_resp);
            //    statusLabel.Text = idn_resp;



            //    // data acquisition
            //    SCPI.Send(meaVch1);
            //    CH1Volt = Encoding.ASCII.GetString(bytes, 0, SCPI.Receive(bytes));//Vout_CH1
            //    Debug.WriteLine(CH1Volt);
               

            //    SCPI.Send(Vch1);
            //    CH1Vset = Encoding.ASCII.GetString(bytes, 0, SCPI.Receive(bytes));//Vset_CH1
            //    Debug.WriteLine(CH1Vset);



            //    //instrument control

            //    if (CH1onOfflg == true)
            //    {
            //        Debug.WriteLine("CH1on");
            //        SCPI.Send(OUTch1ON);
            //    }
            //    else
            //    {
            //        Debug.WriteLine("CH1of");
            //        SCPI.Send(OUTch1OFF);
            //    }

            //    if (CH1Set == true)// requested to change the voltage on CH1
            //    {
            //        CH1Set = false;//reset the flag 
            //        string buffer = "CH1:VOLTage " + CH1Vstrans;//setup the buffer 
            //        SCPI.Send(Encoding.ASCII.GetBytes(buffer));//execute the cmd
            //        Debug.WriteLine("ch1set : " + CH1Set);

            //    }

            //    if (intFlg == true)//recuested to change the output mode 
            //    {
            //        intFlg = false;//reset the flag
            //        string buffer = "OUTPut:TRACK 0";//setup the buffer
            //        SCPI.Send(Encoding.ASCII.GetBytes(buffer));//execute the cmd
            //    }

            //    if (SerFlg == true)
            //    {
            //        SerFlg = false;
            //        string buffer = "OUTPut:TRACK 1";
            //        SCPI.Send(Encoding.ASCII.GetBytes(buffer));
            //    }

            //    if (ParFlg == true)
            //    {
            //        ParFlg = false;
            //        string buffer = "OUTPut:TRACK 2";
            //        SCPI.Send(Encoding.ASCII.GetBytes(buffer));
            //    }
                               
            //}
            //catch (Exception exe)
            //{
            //    MessageBox.Show(Convert.ToString(exe));
            //}
        }

        private void Chart1Roll_Tick(object sender, EventArgs e)
        {
            Task.Run(async () => {
                double voltageCH1 = await _SCPI.getVoltage(CHANNELS.CH1);
                double currentCH1 = await _SCPI.getCurrent(CHANNELS.CH1);
                GridlinesOffset++;
                chart1.Invoke(new Action(() => {
                    CH1vS.Text = Convert.ToString(voltageCH1);
                    CH1aS.Text = Convert.ToString(currentCH1);
                    chart1.Series["Voltage"].Points.AddY(Convert.ToDecimal(voltageCH1));//data point 
                    chart1.Series["Voltage"].Points.RemoveAt(0);
                    chart1.Series["current"].Points.AddY(Convert.ToDecimal(currentCH1));//data point 
                    chart1.Series["current"].Points.RemoveAt(0);
                    chart1.ChartAreas[0].AxisX.MajorGrid.IntervalOffset = -GridlinesOffset;
                    chart1.ChartAreas[1].AxisX.MajorGrid.IntervalOffset = -GridlinesOffset;
                    GridlinesOffset %= (int)chart1.ChartAreas[0].AxisX.MajorGrid.Interval;
                    GridlinesOffset %= (int)chart1.ChartAreas[1].AxisX.MajorGrid.Interval;
                }));

                double voltageCH2 = await _SCPI.getVoltage(CHANNELS.CH2);
                double currentCH2 = await _SCPI.getCurrent(CHANNELS.CH2);
                chart2.Invoke(new Action(() =>
                {
                    CH2vS.Text = Convert.ToString(voltageCH2);
                    CH2aS.Text = Convert.ToString(currentCH2);
                    chart2.Series["Voltage"].Points.AddY(Convert.ToDecimal(voltageCH2));//data point 
                    chart2.Series["Voltage"].Points.RemoveAt(0);
                    chart2.Series["current"].Points.AddY(Convert.ToDecimal(currentCH2));//data point 
                    chart2.Series["current"].Points.RemoveAt(0);
                    chart2.ChartAreas[0].AxisX.MajorGrid.IntervalOffset = -GridlinesOffset;
                    chart2.ChartAreas[1].AxisX.MajorGrid.IntervalOffset = -GridlinesOffset;
                    GridlinesOffset %= (int)chart2.ChartAreas[0].AxisX.MajorGrid.Interval;
                    GridlinesOffset %= (int)chart2.ChartAreas[1].AxisX.MajorGrid.Interval;
                }));

            });

            //Task.Run(async () => {
             
            //});


        }//chart 1
        private void Chart2Roll_Tick(object sender, EventArgs e)
        {
            
        }//chart 2      
        private void timer1_Tick(object sender, EventArgs e)
        {

        }


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
               
            }
        }

        private void Ser_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (Ser_radioButton.Checked)
            {
                Debug.WriteLine("ser");
                
            }

        }

        private void Par_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (Par_RB.Checked)
            {
                Debug.WriteLine("par");
               
            }
        }

        private void CH1onOFF_CheckedChanged(object sender, EventArgs e)
        {
            if (CH1onOFF.Checked)
            {
                CH1onOfflg = true;               
            }
            else
            {
                CH1onOfflg = false;
            }
            Debug.WriteLine(Convert.ToString(CH1onOFF.Checked)+ Convert.ToString(CH1onOfflg));
        }
        private void CH1set_Click(object sender, EventArgs e)
        {
            
        }
        private void terminalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SCPI_terminal SCPI_TER = new SCPI_terminal();
            SCPI_TER.Show();
        }//π

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
    }
}