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
using System.Threading;
using System.Timers;
using SPD3303X_E;
using Timer = System.Windows.Forms.Timer;

namespace Power_Supply_DashBoard
{
    public partial class main : Form
    {
        int GridlinesOffset = 0;
        bool CH1onOfflg = false;
        bool CH2onOfflg = false;
        bool RS1state = true;
        bool RS2state = true;
        const int port = 5025;
        byte[] bytes = new byte[1024];
        public static SocketManagement _SCPI;
        public static Timer Chart1Timer, Chart2Timer;
        double voltageCH1 = 0.0;
        double currentCH1 = 0;
        Thread t;

        public main()
        {
            InitializeComponent();
            Chart1Timer = Chart1Roll;
            Chart2Timer = Chart2Roll;
            for (int i = 0; i < 60; i++)
            {
                chart1.Series["Voltage"].Points.AddY(0);
                chart1.Series["current"].Points.AddY(0);
                chart2.Series["Voltage"].Points.AddY(0);
                chart2.Series["current"].Points.AddY(0);
            }//chart Y axis setup
            t = new Thread(new ThreadStart(() =>
            {
                while (true)
                {
                    if (_SCPI != null)
                    {
                        voltageCH1 = _SCPI.getVoltage(CHANNELS.CH1);
                        currentCH1 = _SCPI.getCurrent(CHANNELS.CH1);
                        double voltageOutCH1 = _SCPI.getOutputVoltage(CHANNELS.CH1);
                        double currentOutCH1 = _SCPI.getOutputCurrent(CHANNELS.CH1);
                        GridlinesOffset++;
                        chart1.Invoke(new Action(() =>
                        {
                            CH1vS.Text = Convert.ToString(voltageCH1);
                            CH1aS.Text = Convert.ToString(currentCH1);
                            CH1vO.Text = Convert.ToString(voltageOutCH1);
                            CH1aO.Text = Convert.ToString(currentOutCH1);
                            chart1.Series["Voltage"].Points.AddY(Convert.ToDecimal(voltageCH1));//data point 
                            chart1.Series["Voltage"].Points.RemoveAt(0);
                            chart1.Series["current"].Points.AddY(Convert.ToDecimal(currentCH1));//data point 
                            chart1.Series["current"].Points.RemoveAt(0);
                            chart1.ChartAreas[0].AxisX.MajorGrid.IntervalOffset = -GridlinesOffset;
                            chart1.ChartAreas[1].AxisX.MajorGrid.IntervalOffset = -GridlinesOffset;
                            GridlinesOffset %= (int)chart1.ChartAreas[0].AxisX.MajorGrid.Interval;
                            GridlinesOffset %= (int)chart1.ChartAreas[1].AxisX.MajorGrid.Interval;
                        }));
                        double voltageCH2 = _SCPI.getVoltage(CHANNELS.CH2);
                        double currentCH2 = _SCPI.getCurrent(CHANNELS.CH2);
                        double voltageOutCH2 = _SCPI.getOutputVoltage(CHANNELS.CH2);
                        double currentOutCH2 = _SCPI.getOutputCurrent(CHANNELS.CH2);

                        chart2.Invoke(new Action(() =>
                        {
                            CH2vS.Text = Convert.ToString(voltageCH2);
                            CH2aS.Text = Convert.ToString(currentCH2);
                            CH2vO.Text = Convert.ToString(voltageOutCH2);
                            CH2aO.Text = Convert.ToString(currentOutCH2);
                            chart2.Series["Voltage"].Points.AddY(Convert.ToDecimal(voltageCH2));//data point 
                            chart2.Series["Voltage"].Points.RemoveAt(0);
                            chart2.Series["current"].Points.AddY(Convert.ToDecimal(currentCH2));//data point 
                            chart2.Series["current"].Points.RemoveAt(0);
                            chart2.ChartAreas[0].AxisX.MajorGrid.IntervalOffset = -GridlinesOffset;
                            chart2.ChartAreas[1].AxisX.MajorGrid.IntervalOffset = -GridlinesOffset;
                            GridlinesOffset %= (int)chart2.ChartAreas[0].AxisX.MajorGrid.Interval;
                            GridlinesOffset %= (int)chart2.ChartAreas[1].AxisX.MajorGrid.Interval;
                        }));
                        DISPLAYS d1 = _SCPI.getDisplay(CHANNELS.CH1);
                        DISPLAYS d2 = _SCPI.getDisplay(CHANNELS.CH2);
                        CONNECTION_MODE connectionMode = _SCPI.getConnectionMode();
                        CHANNELS active = _SCPI.getActiveChannel();
                        if (d1 == DISPLAYS.WAVEFORM)
                        {
                            WaveformCH1.Invoke(new Action(() =>
                            {
                                WaveformCH1.Checked = true;
                            }));
                        }
                        else
                        {
                            WaveformCH1.Invoke(new Action(() =>
                            {
                                WaveformCH1.Checked = false;
                            }));
                        }
                        if (d2 == DISPLAYS.WAVEFORM)
                        {
                            WaveformCH2.Invoke(new Action(() =>
                            {
                                WaveformCH2.Checked = true;
                            }));
                        }
                        else
                        {
                            WaveformCH2.Invoke(new Action(() =>
                            {
                                WaveformCH2.Checked = false;
                            }));
                        }
                        switch (connectionMode)
                        {
                            case CONNECTION_MODE.SERIES:
                                Ser_radioButton.Invoke(new Action(() =>
                                {
                                    Ser_radioButton.Checked = true;
                                }));
                                Int_RadioButton.Invoke(new Action(() =>
                                {
                                    Int_RadioButton.Checked = false;
                                }));
                                Par_RB.Invoke(new Action(() =>
                                {
                                    Par_RB.Checked = false;
                                }));
                                break;

                            case CONNECTION_MODE.PARALLEL:
                                Ser_radioButton.Invoke(new Action(() =>
                                {
                                    Ser_radioButton.Checked = false;
                                }));
                                Int_RadioButton.Invoke(new Action(() =>
                                {
                                    Int_RadioButton.Checked = false;
                                }));
                                Par_RB.Invoke(new Action(() =>
                                {
                                    Par_RB.Checked = true;
                                }));
                                break;

                            case CONNECTION_MODE.INDEPENDENT:
                                Ser_radioButton.Invoke(new Action(() =>
                                {
                                    Ser_radioButton.Checked = false;
                                }));
                                Int_RadioButton.Invoke(new Action(() =>
                                {
                                    Int_RadioButton.Checked = true;
                                }));
                                Par_RB.Invoke(new Action(() =>
                                {
                                    Par_RB.Checked = false;
                                }));
                                break;

                            default:
                                Ser_radioButton.Invoke(new Action(() =>
                                {
                                    Ser_radioButton.Checked = false;
                                }));
                                Int_RadioButton.Invoke(new Action(() =>
                                {
                                    Int_RadioButton.Checked = false;
                                }));
                                Par_RB.Invoke(new Action(() =>
                                {
                                    Par_RB.Checked = false;
                                }));
                                break;
                        }

                        switch (active)
                        {
                            case CHANNELS.CH1:
                                CH1activeRB.Invoke(new Action(() =>
                                {
                                    CH1activeRB.Checked = true;
                                }));
                                CH2activeRB.Invoke(new Action(() =>
                                {
                                    CH2activeRB.Checked = false;
                                }));
                                break;

                            case CHANNELS.CH2:
                                CH1activeRB.Invoke(new Action(() =>
                                {
                                    CH1activeRB.Checked = false;
                                }));
                                CH2activeRB.Invoke(new Action(() =>
                                {
                                    CH2activeRB.Checked = true;
                                }));
                                break;

                            default:
                                Debug.WriteLine("ACTIVE CHANNEL FETCH FAILED");
                                break;
                        }


                        CHANNEL_MODE CH1outputMode = _SCPI.getChannelMode(CHANNELS.CH1);
                        CHANNEL_MODE CH2outputMode = _SCPI.getChannelMode(CHANNELS.CH2);
                        switch (CH1outputMode)
                        {
                            case CHANNEL_MODE.CV:
                                CH1cvRB.Invoke(new Action(() =>
                                {
                                    CH1cvRB.Checked = true;
                                    CH1ccRB.Checked = false;
                                }));
                                break;

                            case CHANNEL_MODE.CC:
                                CH1cvRB.Invoke(new Action(() =>
                                {
                                    CH1cvRB.Checked = false;
                                    CH1ccRB.Checked = true;
                                }));
                                break;
                            default:
                                Debug.WriteLine("CHANNEL CV/CC FETCH FAILED");
                                break;
                        }

                        switch (CH2outputMode)
                        {
                            case CHANNEL_MODE.CV:
                                CH1cvRB.Invoke(new Action(() =>
                                {
                                    CH2cvRB.Checked = true;
                                    CH2ccRB.Checked = false;
                                }));
                                break;

                            case CHANNEL_MODE.CC:
                                CH1cvRB.Invoke(new Action(() =>
                                {
                                    CH2cvRB.Checked = false;
                                    CH2ccRB.Checked = true;
                                }));
                                break;
                            default:
                                Debug.WriteLine("CHANNEL CV/CC FETCH FAILED");
                                break;
                        }
                    }
                    else
                    {
                        Debug.WriteLine("Waiting to connect...");
                    }
                    Thread.Sleep(100);
                }
            }));
            t.Start();
        }

        public void updateData() {
            
        }

        //########################################
        //data acquisition timer(s)
        //########################################
        #region data acquisition
        private void Chart1Roll_Tick(object sender, EventArgs e)
        {
          
                
        }//chart 1


        private void Chart2Roll_Tick(object sender, EventArgs e)
        {
            
        }//chart 2      
        #endregion
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

        //########################################
        //Instrument Memories control functions.
        //########################################
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

        //###################################################################
        //Output Track mode control functions. {Independent/Parallel/Series}
        //###################################################################
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

        //########################################
        //Output Control functions.
        //########################################
        private void CH1onOFF_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Task.Run(async () => {
                    if (CH1onOFF.Checked)
                    {

                        CH1onOfflg = true;
                        await _SCPI.setChannelStatus(CHANNELS.CH1, SWITCH.ON);
                    }
                    else
                    {
                        CH1onOfflg = false;
                        await _SCPI.setChannelStatus(CHANNELS.CH1, SWITCH.OFF);
                    }
                    Debug.WriteLine(Convert.ToString(CH1onOFF.Checked));
                });
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CH2onOFF_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Task.Run( async () => {
                    if (CH2onOFF.Checked)
                    {
                        CH2onOfflg = true;
                        await _SCPI.setChannelStatus(CHANNELS.CH2, SWITCH.ON);
                    }
                    else
                    {
                        CH2onOfflg = false;
                        await _SCPI.setChannelStatus(CHANNELS.CH2, SWITCH.OFF);
                    }
                });
                
                Debug.WriteLine(Convert.ToString(CH1onOFF.Checked));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CH1set_Click(object sender, EventArgs e)
        {
            
        }



        //########################################
        //ToolStrip Items "logic" functions.
        //########################################

        # region ToolStrip Items "logic" functions.
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
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About _about = new About();
            _about.ShowDialog();
        }

        private void main_Load(object sender, EventArgs e)
        {

        }

        private void main_Closing(object sender, FormClosingEventArgs e)
        {
            Debug.WriteLine("closing");
            t.Abort();
        }

        private void DatalogingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart chartdialog = new chart();
            chartdialog.Show();
        }


        #endregion
    }
}