using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
namespace Power_Supply_DashBoard
{
    public partial class chart : Form
    {
        public static AutoResetEvent resetEvent = new AutoResetEvent(false);
        int x;
        int GridlinesOffset = 0;
        private static string path;       
        Thread dataloggingThread;
      
        public chart()
        {
            
            InitializeComponent();

            ch1vE.Checked = chart1.Series["CH1V"].Enabled;
           
                 for (int i = 0; i < 60; i++)
                {
                    chart1.Series["CH1V"].Points.AddY(0);
                    chart1.Series["CH1A"].Points.AddY(0);
                    chart1.Series["CH2A"].Points.AddY(0);
                    chart1.Series["CH2V"].Points.AddY(0);
                    Debug.WriteLine(i + "i");
                }//chart y`y axis setup
                Debug.WriteLine("hello world from chart");         
        }

        private void chart_Load(object sender, EventArgs e)
        {
            string csvPath = Properties.Settings.Default.DataPath + "\\CSV\\";
            if (!Directory.Exists(csvPath))
            {
                Directory.CreateDirectory(csvPath);
            }
            Debug.WriteLine(csvPath);
            string date = DateTime.Now.ToString(new CultureInfo("de-DE")).Replace(":", ".") + ".";
            Debug.WriteLine(date);

            path = csvPath + date + "csv";
            Debug.WriteLine(path);
        }

        #region EnabledSeries

        private void CheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series["CH1V"].Enabled = ch1vE.Checked;
        }
        private void CheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series["CH1A"].Enabled = ch1vE.Checked;
        }
        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series["CH2V"].Enabled = CH12vE.Checked;
        }
        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series["CH2A"].Enabled = CH12vE.Checked;
        }
        #endregion

        private void Timer1_Tick(object sender, EventArgs e)
        {
            GridlinesOffset++;
            x++;
            chart1.Series["CH1V"].Points.AddY(25 * Math.Sin(x));//data point 
            chart1.Series["CH1V"].Points.RemoveAt(0);

            for (int i = 0; i <= 4; i++){
                chart1.Series["CH1A"].Points.AddY(i);//data point 
                chart1.Series["CH1A"].Points.RemoveAt(0);
            }

            for(int i = 0; i >= 4; i--)
            {
                chart1.Series["CH1A"].Points.AddY(i);//data point 
                chart1.Series["CH1A"].Points.RemoveAt(0);
            }
            chart1.ChartAreas[0].AxisX.MajorGrid.IntervalOffset = -GridlinesOffset;
            GridlinesOffset %= (int)chart1.ChartAreas[0].AxisX.MajorGrid.Interval;


        }

        private void Start_Click(object sender, EventArgs e)
        {
            dataloggingThread = new Thread(Logger);
            dataloggingThread.IsBackground = true;
            dataloggingThread.Start();
            start.Enabled = false;
            stop.Enabled = true;
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            start.Enabled = true;
            stop.Enabled = false;
            dataloggingThread.Abort();
            File.Move(path + ".tmp", path);
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            chart1.Series["CH1A"].Points.Clear();
        }

        #region data logger
        private void Logger()
        {
            bool firstrun = true;

            while (true)
            {
                if(main._SCPI != null)
                {
                    Debug.WriteLine("Data logging thread up and running!");
                    StringBuilder headerBuilder = new StringBuilder("Time,");
                    StringBuilder lineBuilder = new StringBuilder(Convert.ToString(DateTime.Now) + ",");

                    #region data aquisition and csv append
                    resetEvent.WaitOne();
                    if (CH1Vout.Checked)
                    {
                        
                        headerBuilder.Append("CH1VOut,");
                        lineBuilder.Append(main.voltageOutCH1 + ",");
                    }

                    if (CH1Aout.Checked)
                    {
                        
                        headerBuilder.Append("CH1AOut,");
                        lineBuilder.Append(main.currentOutCH1 + ",");
                    }

                    if (CH1Vset.Checked)
                    {
                        
                        headerBuilder.Append("CH1VSet,");
                        lineBuilder.Append(main.voltageCH1 + ",");
                    }

                    if (CH1Aset.Checked)
                    {
                        
                        headerBuilder.Append("CH1ASet,");
                        lineBuilder.Append(main.currentCH1 + ",");
                    }

                    if (CH2Vout.Checked)
                    {
                        
                        headerBuilder.Append("CH2VOut,");
                        lineBuilder.Append(main.voltageOutCH2 + ",");
                    }

                    if (CH2Aout.Checked)
                    {
                        
                        headerBuilder.Append("CH2AOut,");
                        lineBuilder.Append(main.currentOutCH2 + ",");
                    }

                    if (CH2Vset.Checked)
                    {
                        
                        headerBuilder.Append("CH1VSet,");
                        lineBuilder.Append(main.voltageCH2 + ",");
                    }

                    if (CH2Aset.Checked)
                    {
                        
                        headerBuilder.Append("CH2ASet");
                        lineBuilder.Append(main.currentCH2 + ",");
                    }

                    #endregion

                    using (StreamWriter writer = new StreamWriter(path+".tmp", true))  //write data
                    {
                        if (firstrun)
                        {
                            writer.WriteLine(headerBuilder.ToString());
                        }
                        writer.WriteLine(lineBuilder.ToString());
                        writer.Flush();
                    }
                    firstrun = false;

                }
                else
                {
                    Debug.WriteLine("Data logging thread waiting...");
                }
            }
        }

        #endregion

        private void scrsh_Click(object sender, EventArgs e)
        {
            string imagePath = Properties.Settings.Default.DataPath + "\\Images\\";
            if (!Directory.Exists(imagePath))
            {
                Directory.CreateDirectory(imagePath);
            }
            Debug.WriteLine(imagePath);
            string date = DateTime.Now.ToString(new CultureInfo("de-DE")).Replace(":", ".") + ".";
            Debug.WriteLine(date);

            string imgpath = imagePath + date + "jpeg";

            Debug.WriteLine(imgpath);
            if (path != null)
            {
                chart1.SaveImage(imgpath, ChartImageFormat.Jpeg);
            }
        }
    }
}
