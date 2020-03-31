using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        int x;
        int GridlinesOffset = 0;
        static string path;
        SaveFileDialog saveFileDialog1 = new SaveFileDialog();

        
        Thread datalogingThread = new Thread(Datalog);
      
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

            saveFileDialog1.Filter = "coma separated values|*.csv";
            saveFileDialog1.Title = "path to dataloging file";
         
        }

        private void CheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series["CH1V"].Enabled = ch1vE.Checked;
        }

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

        private void SaveFile_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            path = saveFileDialog1.FileName;
            pathTextbox.Text = path;
            datalogingThread.IsBackground = true;
            datalogingThread.Start();
        }

        static void Datalog()
        {
            while (true)
            {
                using (StreamWriter file = new StreamWriter(path, true))
                {
                    file.WriteLine(Convert.ToString(DateTime.Now));
                }

                Thread.Sleep(1000);
            }
        }

        private void CheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series["CH1A"].Enabled = ch1vE.Checked;
        }
        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series["CH1V"].Enabled = CH12vE.Checked;
        }

        private void Start_Click(object sender, EventArgs e)
        {

        }

        private void Stop_Click(object sender, EventArgs e)
        {

        }

        private void Clear_Click(object sender, EventArgs e)
        {
            chart1.Series["CH1A"].Points.Clear();
        }

       
    }
}
