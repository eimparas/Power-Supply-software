﻿namespace Power_Supply_DashBoard
{
    partial class chart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.DataLogBox = new System.Windows.Forms.GroupBox();
            this.stop = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.CH2Aout = new System.Windows.Forms.CheckBox();
            this.CH2Aset = new System.Windows.Forms.CheckBox();
            this.CH2Vout = new System.Windows.Forms.CheckBox();
            this.CH2Vset = new System.Windows.Forms.CheckBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.CH1Aout = new System.Windows.Forms.CheckBox();
            this.CH1Aset = new System.Windows.Forms.CheckBox();
            this.CH1Vset = new System.Windows.Forms.CheckBox();
            this.CH1Vout = new System.Windows.Forms.CheckBox();
            this.Chart_ctrl_gbox = new System.Windows.Forms.GroupBox();
            this.Clear = new System.Windows.Forms.Button();
            this.scrsh = new System.Windows.Forms.Button();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.CH12vE = new System.Windows.Forms.CheckBox();
            this.ch1vE = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.DataLogBox.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.Chart_ctrl_gbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AxisX.Maximum = 60D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisY.Maximum = 32D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY2.Maximum = 4D;
            chartArea1.AxisY2.Minimum = 0D;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 13);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Enabled = false;
            series1.Legend = "Legend1";
            series1.Name = "CH1V";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Enabled = false;
            series2.Legend = "Legend1";
            series2.Name = "CH2V";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Enabled = false;
            series3.Legend = "Legend1";
            series3.Name = "CH1A";
            series3.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series4.Enabled = false;
            series4.Legend = "Legend1";
            series4.Name = "CH2A";
            series4.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(887, 425);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart";
            // 
            // DataLogBox
            // 
            this.DataLogBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DataLogBox.Controls.Add(this.stop);
            this.DataLogBox.Controls.Add(this.start);
            this.DataLogBox.Controls.Add(this.groupBox10);
            this.DataLogBox.Controls.Add(this.groupBox9);
            this.DataLogBox.Location = new System.Drawing.Point(914, 226);
            this.DataLogBox.Name = "DataLogBox";
            this.DataLogBox.Size = new System.Drawing.Size(197, 212);
            this.DataLogBox.TabIndex = 11;
            this.DataLogBox.TabStop = false;
            this.DataLogBox.Text = "Dataloging";
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(142, 182);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(37, 23);
            this.stop.TabIndex = 7;
            this.stop.Text = "stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(99, 182);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(37, 23);
            this.start.TabIndex = 6;
            this.start.Text = "start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.Start_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox10.Controls.Add(this.CH2Aout);
            this.groupBox10.Controls.Add(this.CH2Aset);
            this.groupBox10.Controls.Add(this.CH2Vout);
            this.groupBox10.Controls.Add(this.CH2Vset);
            this.groupBox10.Location = new System.Drawing.Point(7, 110);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(71, 95);
            this.groupBox10.TabIndex = 3;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "CH2";
            // 
            // CH2Aout
            // 
            this.CH2Aout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CH2Aout.AutoSize = true;
            this.CH2Aout.Location = new System.Drawing.Point(6, 69);
            this.CH2Aout.Name = "CH2Aout";
            this.CH2Aout.Size = new System.Drawing.Size(48, 17);
            this.CH2Aout.TabIndex = 7;
            this.CH2Aout.Text = "Aout";
            this.CH2Aout.UseVisualStyleBackColor = true;
            // 
            // CH2Aset
            // 
            this.CH2Aset.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CH2Aset.AutoSize = true;
            this.CH2Aset.Location = new System.Drawing.Point(6, 52);
            this.CH2Aset.Name = "CH2Aset";
            this.CH2Aset.Size = new System.Drawing.Size(47, 17);
            this.CH2Aset.TabIndex = 6;
            this.CH2Aset.Text = "Aset";
            this.CH2Aset.UseVisualStyleBackColor = true;
            // 
            // CH2Vout
            // 
            this.CH2Vout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CH2Vout.AutoSize = true;
            this.CH2Vout.Location = new System.Drawing.Point(6, 18);
            this.CH2Vout.Name = "CH2Vout";
            this.CH2Vout.Size = new System.Drawing.Size(48, 17);
            this.CH2Vout.TabIndex = 4;
            this.CH2Vout.Text = "Vout";
            this.CH2Vout.UseVisualStyleBackColor = true;
            // 
            // CH2Vset
            // 
            this.CH2Vset.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CH2Vset.AutoSize = true;
            this.CH2Vset.Location = new System.Drawing.Point(6, 35);
            this.CH2Vset.Name = "CH2Vset";
            this.CH2Vset.Size = new System.Drawing.Size(47, 17);
            this.CH2Vset.TabIndex = 5;
            this.CH2Vset.Text = "Vset";
            this.CH2Vset.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox9.Controls.Add(this.CH1Aout);
            this.groupBox9.Controls.Add(this.CH1Aset);
            this.groupBox9.Controls.Add(this.CH1Vset);
            this.groupBox9.Controls.Add(this.CH1Vout);
            this.groupBox9.Location = new System.Drawing.Point(7, 19);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(71, 90);
            this.groupBox9.TabIndex = 2;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "CH1";
            // 
            // CH1Aout
            // 
            this.CH1Aout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CH1Aout.AutoSize = true;
            this.CH1Aout.Location = new System.Drawing.Point(6, 70);
            this.CH1Aout.Name = "CH1Aout";
            this.CH1Aout.Size = new System.Drawing.Size(48, 17);
            this.CH1Aout.TabIndex = 3;
            this.CH1Aout.Text = "Aout";
            this.CH1Aout.UseVisualStyleBackColor = true;
            // 
            // CH1Aset
            // 
            this.CH1Aset.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CH1Aset.AutoSize = true;
            this.CH1Aset.Location = new System.Drawing.Point(6, 53);
            this.CH1Aset.Name = "CH1Aset";
            this.CH1Aset.Size = new System.Drawing.Size(47, 17);
            this.CH1Aset.TabIndex = 2;
            this.CH1Aset.Text = "Aset";
            this.CH1Aset.UseVisualStyleBackColor = true;
            // 
            // CH1Vset
            // 
            this.CH1Vset.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CH1Vset.AutoSize = true;
            this.CH1Vset.Location = new System.Drawing.Point(6, 36);
            this.CH1Vset.Name = "CH1Vset";
            this.CH1Vset.Size = new System.Drawing.Size(47, 17);
            this.CH1Vset.TabIndex = 1;
            this.CH1Vset.Text = "Vset";
            this.CH1Vset.UseVisualStyleBackColor = true;
            // 
            // CH1Vout
            // 
            this.CH1Vout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CH1Vout.AutoSize = true;
            this.CH1Vout.Location = new System.Drawing.Point(6, 19);
            this.CH1Vout.Name = "CH1Vout";
            this.CH1Vout.Size = new System.Drawing.Size(48, 17);
            this.CH1Vout.TabIndex = 0;
            this.CH1Vout.Text = "Vout";
            this.CH1Vout.UseVisualStyleBackColor = true;
            // 
            // Chart_ctrl_gbox
            // 
            this.Chart_ctrl_gbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Chart_ctrl_gbox.Controls.Add(this.Clear);
            this.Chart_ctrl_gbox.Controls.Add(this.scrsh);
            this.Chart_ctrl_gbox.Controls.Add(this.checkBox8);
            this.Chart_ctrl_gbox.Controls.Add(this.checkBox7);
            this.Chart_ctrl_gbox.Controls.Add(this.CH12vE);
            this.Chart_ctrl_gbox.Controls.Add(this.ch1vE);
            this.Chart_ctrl_gbox.Location = new System.Drawing.Point(914, 10);
            this.Chart_ctrl_gbox.Name = "Chart_ctrl_gbox";
            this.Chart_ctrl_gbox.Size = new System.Drawing.Size(196, 114);
            this.Chart_ctrl_gbox.TabIndex = 12;
            this.Chart_ctrl_gbox.TabStop = false;
            this.Chart_ctrl_gbox.Text = "Chart control";
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(93, 45);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(75, 23);
            this.Clear.TabIndex = 5;
            this.Clear.Text = "clear chart";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // scrsh
            // 
            this.scrsh.Location = new System.Drawing.Point(93, 16);
            this.scrsh.Name = "scrsh";
            this.scrsh.Size = new System.Drawing.Size(75, 23);
            this.scrsh.TabIndex = 4;
            this.scrsh.Text = "screenshoot";
            this.scrsh.UseVisualStyleBackColor = true;
            this.scrsh.Click += new System.EventHandler(this.scrsh_Click);
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(7, 89);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(54, 17);
            this.checkBox8.TabIndex = 3;
            this.checkBox8.Text = "CH2A";
            this.checkBox8.UseVisualStyleBackColor = true;
            this.checkBox8.CheckedChanged += new System.EventHandler(this.checkBox8_CheckedChanged);
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(7, 66);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(54, 17);
            this.checkBox7.TabIndex = 2;
            this.checkBox7.Text = "CH1A";
            this.checkBox7.UseVisualStyleBackColor = true;
            this.checkBox7.CheckedChanged += new System.EventHandler(this.checkBox7_CheckedChanged);
            // 
            // CH12vE
            // 
            this.CH12vE.AutoSize = true;
            this.CH12vE.Location = new System.Drawing.Point(7, 43);
            this.CH12vE.Name = "CH12vE";
            this.CH12vE.Size = new System.Drawing.Size(54, 17);
            this.CH12vE.TabIndex = 1;
            this.CH12vE.Text = "CH2V";
            this.CH12vE.UseVisualStyleBackColor = true;
            this.CH12vE.CheckedChanged += new System.EventHandler(this.CheckBox6_CheckedChanged);
            // 
            // ch1vE
            // 
            this.ch1vE.AutoSize = true;
            this.ch1vE.Location = new System.Drawing.Point(7, 20);
            this.ch1vE.Name = "ch1vE";
            this.ch1vE.Size = new System.Drawing.Size(54, 17);
            this.ch1vE.TabIndex = 0;
            this.ch1vE.Text = "CH1V";
            this.ch1vE.UseVisualStyleBackColor = true;
            this.ch1vE.CheckedChanged += new System.EventHandler(this.CheckBox5_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // chart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 450);
            this.Controls.Add(this.Chart_ctrl_gbox);
            this.Controls.Add(this.DataLogBox);
            this.Controls.Add(this.chart1);
            this.Name = "chart";
            this.Text = "chart";
            this.Load += new System.EventHandler(this.chart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.DataLogBox.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.Chart_ctrl_gbox.ResumeLayout(false);
            this.Chart_ctrl_gbox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.GroupBox DataLogBox;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.CheckBox CH2Aout;
        private System.Windows.Forms.CheckBox CH2Aset;
        private System.Windows.Forms.CheckBox CH2Vout;
        private System.Windows.Forms.CheckBox CH2Vset;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.CheckBox CH1Aout;
        private System.Windows.Forms.CheckBox CH1Aset;
        private System.Windows.Forms.CheckBox CH1Vset;
        private System.Windows.Forms.CheckBox CH1Vout;
        private System.Windows.Forms.GroupBox Chart_ctrl_gbox;
        private System.Windows.Forms.CheckBox ch1vE;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button scrsh;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox CH12vE;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Button start;
    }
}