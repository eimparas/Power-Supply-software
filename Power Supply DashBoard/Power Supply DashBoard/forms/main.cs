﻿using System;
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
        double voltageCH1 = 0.0;
        double currentCH1 = 0.0;
        double powerCH1 = 0.0;
        double voltageOutCH1 = 0.0;
        double currentOutCH1 = 0.0;
        double voltageCH2 = 0.0;
        double currentCH2= 0.0;
        double voltageOutCH2= 0.0;
        double currentOutCH2= 0.0;
        double powerCH2 = 0.0;

        Thread t;

        public main()
        {
            InitializeComponent();
            for (int i = 0; i < 60; i++)
            {
                chart1.Series["Voltage"].Points.AddY(0);
                chart1.Series["current"].Points.AddY(0);
                chart2.Series["Voltage"].Points.AddY(0);
                chart2.Series["current"].Points.AddY(0);
            }//chart Y axis setup
            
            //########################################
            //data acquisition 
            //########################################
            #region data acquisition
            t = new Thread(new ThreadStart(() =>
            {
                while (true)
                {
                    if (_SCPI != null)
                    {
                        Debug.WriteLine("living");
                        //########################################
                        //Voltage Current parameters from instrument
                        //########################################
                        #region ADC_reading
                        voltageCH1 = _SCPI.getVoltage(CHANNELS.CH1);
                        currentCH1 = _SCPI.getCurrent(CHANNELS.CH1);//Voltage/Current Setpoint
                        voltageOutCH1 = _SCPI.getOutputVoltage(CHANNELS.CH1);
                        currentOutCH1 = _SCPI.getOutputCurrent(CHANNELS.CH1);
                        powerCH1 = _SCPI.getOutputPower(CHANNELS.CH1);//MEasUreed Voltage/Current/Power from ADC

                        voltageCH2 = _SCPI.getVoltage(CHANNELS.CH2);
                        currentCH2 = _SCPI.getCurrent(CHANNELS.CH2);//Voltage/Current Setpoint
                        voltageOutCH2 = _SCPI.getOutputVoltage(CHANNELS.CH2);
                        currentOutCH2 = _SCPI.getOutputCurrent(CHANNELS.CH2);
                        powerCH2 = _SCPI.getOutputPower(CHANNELS.CH2);//MEasUreed Voltage/Current/power from ADC
                        #endregion

                        #region Status
                        CHANNEL_MODE CH1outputMode = _SCPI.getChannelMode(CHANNELS.CH1);
                        CHANNEL_MODE CH2outputMode = _SCPI.getChannelMode(CHANNELS.CH2);//CV-CC
                        DISPLAYS d1 = _SCPI.getDisplay(CHANNELS.CH1);
                        DISPLAYS d2 = _SCPI.getDisplay(CHANNELS.CH2);//Num-Waveform
                        CONNECTION_MODE connectionMode = _SCPI.getConnectionMode();//Serial-Parallel
                        CHANNELS active = _SCPI.getActiveChannel();
                        
                        //Missing CH out on off & TImer on off 
                        #endregion

                        //###########
                        //GUI Writes
                        //###########
                        GridlinesOffset++;
                        chart1.Invoke(new Action(() =>
                        {
                            CH1vS.Text = Convert.ToString(voltageCH1);
                            CH1aS.Text = Convert.ToString(currentCH1);
                            CH1vO.Text = Convert.ToString(voltageOutCH1);
                            CH1aO.Text = Convert.ToString(currentOutCH1);
                            chart1.Series["Voltage"].Points.AddY(Convert.ToDecimal(voltageOutCH1));//data point 
                            chart1.Series["Voltage"].Points.RemoveAt(0);
                            chart1.Series["current"].Points.AddY(Convert.ToDecimal(currentOutCH1));//data point 
                            chart1.Series["current"].Points.RemoveAt(0);
                            chart1.ChartAreas[0].AxisX.MajorGrid.IntervalOffset = -GridlinesOffset;
                            chart1.ChartAreas[1].AxisX.MajorGrid.IntervalOffset = -GridlinesOffset;
                            GridlinesOffset %= (int)chart1.ChartAreas[0].AxisX.MajorGrid.Interval;
                            GridlinesOffset %= (int)chart1.ChartAreas[1].AxisX.MajorGrid.Interval;
                        }));
                        
                        chart2.Invoke(new Action(() =>
                        {
                            CH2vS.Text = Convert.ToString(voltageCH2);
                            CH2aS.Text = Convert.ToString(currentCH2);
                            CH2vO.Text = Convert.ToString(voltageOutCH2);
                            CH2aO.Text = Convert.ToString(currentOutCH2);
                            chart2.Series["Voltage"].Points.AddY(Convert.ToDecimal(voltageOutCH2));//data point 
                            chart2.Series["Voltage"].Points.RemoveAt(0);
                            chart2.Series["current"].Points.AddY(Convert.ToDecimal(currentOutCH2));//data point 
                            chart2.Series["current"].Points.RemoveAt(0);
                            chart2.ChartAreas[0].AxisX.MajorGrid.IntervalOffset = -GridlinesOffset;
                            chart2.ChartAreas[1].AxisX.MajorGrid.IntervalOffset = -GridlinesOffset;
                            GridlinesOffset %= (int)chart2.ChartAreas[0].AxisX.MajorGrid.Interval;
                            GridlinesOffset %= (int)chart2.ChartAreas[1].AxisX.MajorGrid.Interval;
                        }));                      
                        
                        
                        if (d1 == DISPLAYS.WAVEFORM)
                        {
                            WaveformCH1s.Invoke(new Action(() =>
                            {
                                WaveformCH1s.Checked = true;
                            }));
                        }
                        else
                        {
                            WaveformCH1s.Invoke(new Action(() =>
                            {
                                WaveformCH1s.Checked = false;
                            }));
                        }
                        if (d2 == DISPLAYS.WAVEFORM)
                        {
                            WaveformCH2s.Invoke(new Action(() =>
                            {
                                WaveformCH2s.Checked = true;
                            }));
                        }
                        else
                        {
                            WaveformCH2s.Invoke(new Action(() =>
                            {
                                WaveformCH2s.Checked = false;
                            }));
                        }
                        switch (connectionMode)
                        {
                            case CONNECTION_MODE.SERIES:
                                ser_RBs.Invoke(new Action(() =>
                                {
                                    ser_RBs.Checked = true;
                                }));
                                Int_RBs.Invoke(new Action(() =>
                                {
                                    Int_RBs.Checked = false;
                                }));
                                Par_RBs.Invoke(new Action(() =>
                                {
                                    Par_RBs.Checked = false;
                                }));
                                break;

                            case CONNECTION_MODE.PARALLEL:
                                ser_RBs.Invoke(new Action(() =>
                                {
                                    ser_RBs.Checked = false;
                                }));
                                Int_RBs.Invoke(new Action(() =>
                                {
                                   Int_RBs.Checked = false;
                                }));
                                Par_RBs.Invoke(new Action(() =>
                                {
                                    Par_RBs.Checked = true;
                                }));
                                break;

                            case CONNECTION_MODE.INDEPENDENT:
                                ser_RBs.Invoke(new Action(() =>
                                {
                                    ser_RBs.Checked = false;
                                }));
                                Int_RBs.Invoke(new Action(() =>
                                {
                                    Int_RBs.Checked = true;
                                }));
                                Par_RBs.Invoke(new Action(() =>
                                {
                                    Par_RBs.Checked = false;
                                }));
                                break;

                            default:
                                ser_RBs.Invoke(new Action(() =>
                                {
                                    ser_RBs.Checked = false;
                                }));
                                Int_RBs.Invoke(new Action(() =>
                                {
                                    Int_RBs.Checked = false;
                                }));
                                Par_RBs.Invoke(new Action(() =>
                                {
                                    Par_RBs.Checked = false;
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
        #endregion

        //########################################
        //Instrument Memories control functions.
        //########################################
        #region Memories
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
            tabControl1.SelectedIndex = 1;
        }
        #endregion

        //###################################################################
        //Output Track mode control functions. {Independent/Parallel/Series}
        //###################################################################
        #region OutTrackMode
        private void Int_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (Int_RadioButton.Checked)
            {
                Debug.WriteLine("int");
                _SCPI.setChannelConnection(CONNECTION_MODE.INDEPENDENT);
               
            }
        }

        private void Ser_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (Ser_radioButton.Checked)
            {
                Debug.WriteLine("ser");
                _SCPI.setChannelConnection(CONNECTION_MODE.SERIES);
            }

        }

        private void  Par_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (Par_RB.Checked)
            {
                Debug.WriteLine("par");
                _SCPI.setChannelConnection(CONNECTION_MODE.PARALLEL);
               
            }
        }
        #endregion

        //########################################
        //Output Control functions.
        //########################################
        #region OutControl
        private void CH1onOFF_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Task.Run(async () => {
                    if (CH1onOFF.Checked)
                    {

                       // CH1onOfflg = true;
                        await _SCPI.setChannelStatus(CHANNELS.CH1, SWITCH.ON);
                    }
                    else
                    {
                        //CH1onOfflg = false;
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
                       // CH2onOfflg = true;
                        await _SCPI.setChannelStatus(CHANNELS.CH2, SWITCH.ON);
                    }
                    else
                    {
                       // CH2onOfflg = false;
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


        private void CH3onOFF_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Task.Run(async () => {
                    if (CH3onOFF.Checked)
                    {

                        //CH3onOfflg = true;
                        await _SCPI.setChannelStatus(CHANNELS.CH3, SWITCH.ON);
                    }
                    else
                    {
                        //CH3onOfflg = false;
                        await _SCPI.setChannelStatus(CHANNELS.CH3, SWITCH.OFF);
                    }
                    Debug.WriteLine(Convert.ToString(CH1onOFF.Checked));
                });

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Sets CH1 Voltage
        private async void CH1set_Click(object sender, EventArgs e)
        {
            if(CH1vText.Text.Length > 0)
            {
                try
                {
                    await _SCPI.setVoltage(CHANNELS.CH1, Double.Parse(CH1vText.Text));
   
                }
                catch (FormatException)
                {
                    Debug.WriteLine("An idiot entered invalid input CH1");
                }
            }
        }
        //Sets CH2 Voltage
        private async void CH2set_Click(object sender, EventArgs e)
        {
            if (CH2vText.Text.Length > 0)
            {
                try
                {

                    await _SCPI.setVoltage(CHANNELS.CH2, Double.Parse(CH2vText.Text));

                }
                catch (FormatException)
                {
                    Debug.WriteLine("An idiot entered invalid input CH2");
                }
            }
        }

        //Sets CH1 Current
        private async void CH1setC_Click(object sender, EventArgs e)
        {
            if (CH1aText.Text.Length > 0)
            {
                try
                {
                    await _SCPI.setCurrent(CHANNELS.CH1, Double.Parse(CH1aText.Text));

                }
                catch (FormatException)
                {
                    Debug.WriteLine("An idiot entered invalid input CH1");
                }
            }
        }

        //Sets CH2 Current
        private async void CH2setC_Click(object sender, EventArgs e)
        {
            if (CH2aText.Text.Length > 0)
            {
                try
                {
                    await _SCPI.setCurrent(CHANNELS.CH2, Double.Parse(CH2aText.Text));

                }
                catch (FormatException)
                {
                    Debug.WriteLine("An idiot entered invalid input CH1");
                }
            }
        }

        #endregion

        //########################################
        //ToolStrip Items "logic" functions.
        //########################################
        # region ToolStrip Items "logic" functions.
        private void terminalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SCPI_terminal SCPI_TER = new SCPI_terminal();
            SCPI_TER.Show();
        }
        private void NetworkSetingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            networksetup netset = new networksetup();
            netset.StartPosition = FormStartPosition.CenterParent;
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
            _about.StartPosition = FormStartPosition.CenterParent;
            _about.ShowDialog();
        }
        private void DatalogingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart chartdialog = new chart();
            chartdialog.Show();
        }
        #endregion

        //########################################
        // Front Pannel Control
        //########################################
        #region FrontPannelControl

        private async void WaveformCH1_CheckedChanged(object sender, EventArgs e)
        {
            if (WaveformCH1.Checked)
            {
                _SCPI.setWaveformDisplay(CHANNELS.CH1, SWITCH.ON);
            }
            else
            {
                _SCPI.setWaveformDisplay(CHANNELS.CH1, SWITCH.OFF);
            }
        }

        private async void WaveformCH2_CheckedChanged(object sender, EventArgs e)
        {
            if (WaveformCH2.Checked)
            {
                _SCPI.setWaveformDisplay(CHANNELS.CH2, SWITCH.ON);
            }
            else
            {
                _SCPI.setWaveformDisplay(CHANNELS.CH2, SWITCH.OFF);
            }
        }
        #endregion   

        private void main_Closing(object sender, FormClosingEventArgs e)
        {
            Debug.WriteLine("closing");
            t.Abort();
        }
    }
}