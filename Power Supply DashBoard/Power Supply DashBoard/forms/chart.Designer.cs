namespace Power_Supply_DashBoard
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
            this.SaveFile = new System.Windows.Forms.Button();
            this.pathTextbox = new System.Windows.Forms.TextBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.Aout = new System.Windows.Forms.CheckBox();
            this.Aset = new System.Windows.Forms.CheckBox();
            this.Vset = new System.Windows.Forms.CheckBox();
            this.Vout = new System.Windows.Forms.CheckBox();
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
            series1.Legend = "Legend1";
            series1.Name = "CH1V";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "CH2V";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Legend = "Legend1";
            series3.Name = "CH1A";
            series3.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
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
            this.DataLogBox.Controls.Add(this.SaveFile);
            this.DataLogBox.Controls.Add(this.pathTextbox);
            this.DataLogBox.Controls.Add(this.groupBox10);
            this.DataLogBox.Controls.Add(this.groupBox9);
            this.DataLogBox.Location = new System.Drawing.Point(914, 194);
            this.DataLogBox.Name = "DataLogBox";
            this.DataLogBox.Size = new System.Drawing.Size(197, 244);
            this.DataLogBox.TabIndex = 11;
            this.DataLogBox.TabStop = false;
            this.DataLogBox.Text = "Dataloging";
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(132, 77);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(37, 23);
            this.stop.TabIndex = 7;
            this.stop.Text = "stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(89, 77);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(37, 23);
            this.start.TabIndex = 6;
            this.start.Text = "start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.Start_Click);
            // 
            // SaveFile
            // 
            this.SaveFile.Image = global::Power_Supply_DashBoard.Properties.Resources.save;
            this.SaveFile.Location = new System.Drawing.Point(151, 13);
            this.SaveFile.Name = "SaveFile";
            this.SaveFile.Size = new System.Drawing.Size(40, 34);
            this.SaveFile.TabIndex = 5;
            this.SaveFile.UseVisualStyleBackColor = true;
            this.SaveFile.Click += new System.EventHandler(this.SaveFile_Click);
            // 
            // pathTextbox
            // 
            this.pathTextbox.Location = new System.Drawing.Point(1, 21);
            this.pathTextbox.Name = "pathTextbox";
            this.pathTextbox.Size = new System.Drawing.Size(144, 20);
            this.pathTextbox.TabIndex = 4;
            // 
            // groupBox10
            // 
            this.groupBox10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox10.Controls.Add(this.checkBox1);
            this.groupBox10.Controls.Add(this.checkBox2);
            this.groupBox10.Controls.Add(this.checkBox4);
            this.groupBox10.Controls.Add(this.checkBox3);
            this.groupBox10.Location = new System.Drawing.Point(12, 138);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(71, 95);
            this.groupBox10.TabIndex = 3;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "CH2";
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 69);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(48, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Aout";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(6, 52);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(47, 17);
            this.checkBox2.TabIndex = 6;
            this.checkBox2.Text = "Aset";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(6, 18);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(48, 17);
            this.checkBox4.TabIndex = 4;
            this.checkBox4.Text = "Vout";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(6, 35);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(47, 17);
            this.checkBox3.TabIndex = 5;
            this.checkBox3.Text = "Vset";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox9.Controls.Add(this.Aout);
            this.groupBox9.Controls.Add(this.Aset);
            this.groupBox9.Controls.Add(this.Vset);
            this.groupBox9.Controls.Add(this.Vout);
            this.groupBox9.Location = new System.Drawing.Point(12, 47);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(71, 90);
            this.groupBox9.TabIndex = 2;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "CH1";
            // 
            // Aout
            // 
            this.Aout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Aout.AutoSize = true;
            this.Aout.Location = new System.Drawing.Point(6, 70);
            this.Aout.Name = "Aout";
            this.Aout.Size = new System.Drawing.Size(48, 17);
            this.Aout.TabIndex = 3;
            this.Aout.Text = "Aout";
            this.Aout.UseVisualStyleBackColor = true;
            // 
            // Aset
            // 
            this.Aset.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Aset.AutoSize = true;
            this.Aset.Location = new System.Drawing.Point(6, 53);
            this.Aset.Name = "Aset";
            this.Aset.Size = new System.Drawing.Size(47, 17);
            this.Aset.TabIndex = 2;
            this.Aset.Text = "Aset";
            this.Aset.UseVisualStyleBackColor = true;
            // 
            // Vset
            // 
            this.Vset.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Vset.AutoSize = true;
            this.Vset.Location = new System.Drawing.Point(6, 36);
            this.Vset.Name = "Vset";
            this.Vset.Size = new System.Drawing.Size(47, 17);
            this.Vset.TabIndex = 1;
            this.Vset.Text = "Vset";
            this.Vset.UseVisualStyleBackColor = true;
            // 
            // Vout
            // 
            this.Vout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Vout.AutoSize = true;
            this.Vout.Location = new System.Drawing.Point(6, 19);
            this.Vout.Name = "Vout";
            this.Vout.Size = new System.Drawing.Size(48, 17);
            this.Vout.TabIndex = 0;
            this.Vout.Text = "Vout";
            this.Vout.UseVisualStyleBackColor = true;
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
            this.Chart_ctrl_gbox.Size = new System.Drawing.Size(196, 184);
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
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.DataLogBox.ResumeLayout(false);
            this.DataLogBox.PerformLayout();
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
        private System.Windows.Forms.Button SaveFile;
        private System.Windows.Forms.TextBox pathTextbox;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.CheckBox Aout;
        private System.Windows.Forms.CheckBox Aset;
        private System.Windows.Forms.CheckBox Vset;
        private System.Windows.Forms.CheckBox Vout;
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