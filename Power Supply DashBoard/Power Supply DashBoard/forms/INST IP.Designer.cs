namespace Power_Supply_DashBoard
{
    partial class INST_IP
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
            this.dhcp = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.gw4 = new System.Windows.Forms.TextBox();
            this.gw3 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.gw2 = new System.Windows.Forms.TextBox();
            this.gw1 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.sb4 = new System.Windows.Forms.TextBox();
            this.sb3 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.sb2 = new System.Windows.Forms.TextBox();
            this.sb1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.ip4 = new System.Windows.Forms.TextBox();
            this.ip3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ip2 = new System.Windows.Forms.TextBox();
            this.ip1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.apply = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dhcp
            // 
            this.dhcp.AutoSize = true;
            this.dhcp.Location = new System.Drawing.Point(12, 12);
            this.dhcp.Name = "dhcp";
            this.dhcp.Size = new System.Drawing.Size(55, 17);
            this.dhcp.TabIndex = 0;
            this.dhcp.TabStop = true;
            this.dhcp.Text = "DHCP";
            this.dhcp.UseVisualStyleBackColor = true;
            this.dhcp.CheckedChanged += new System.EventHandler(this.Dhcp_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(76, 12);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(61, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "static ip";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(318, 119);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IP setings ";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.gw4);
            this.panel3.Controls.Add(this.gw3);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.gw2);
            this.panel3.Controls.Add(this.gw1);
            this.panel3.Location = new System.Drawing.Point(6, 79);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(209, 23);
            this.panel3.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(150, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(10, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = ".";
            // 
            // gw4
            // 
            this.gw4.Location = new System.Drawing.Point(166, 0);
            this.gw4.MaxLength = 3;
            this.gw4.Name = "gw4";
            this.gw4.Size = new System.Drawing.Size(32, 20);
            this.gw4.TabIndex = 11;
            this.gw4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.key);
            // 
            // gw3
            // 
            this.gw3.Location = new System.Drawing.Point(118, 0);
            this.gw3.MaxLength = 3;
            this.gw3.Name = "gw3";
            this.gw3.Size = new System.Drawing.Size(32, 20);
            this.gw3.TabIndex = 10;
            this.gw3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.key);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(102, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(10, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = ".";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(48, 8);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(10, 13);
            this.label12.TabIndex = 7;
            this.label12.Text = ".";
            // 
            // gw2
            // 
            this.gw2.Location = new System.Drawing.Point(63, 0);
            this.gw2.MaxLength = 3;
            this.gw2.Name = "gw2";
            this.gw2.Size = new System.Drawing.Size(32, 20);
            this.gw2.TabIndex = 4;
            this.gw2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.key);
            // 
            // gw1
            // 
            this.gw1.Location = new System.Drawing.Point(10, 0);
            this.gw1.MaxLength = 3;
            this.gw1.Name = "gw1";
            this.gw1.Size = new System.Drawing.Size(32, 20);
            this.gw1.TabIndex = 3;
            this.gw1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.key);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.sb4);
            this.panel2.Controls.Add(this.sb3);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.sb2);
            this.panel2.Controls.Add(this.sb1);
            this.panel2.Location = new System.Drawing.Point(6, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(209, 23);
            this.panel2.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(150, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(10, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = ".";
            // 
            // sb4
            // 
            this.sb4.Location = new System.Drawing.Point(166, 0);
            this.sb4.MaxLength = 3;
            this.sb4.Name = "sb4";
            this.sb4.Size = new System.Drawing.Size(32, 20);
            this.sb4.TabIndex = 11;
            this.sb4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.key);
            // 
            // sb3
            // 
            this.sb3.Location = new System.Drawing.Point(118, 0);
            this.sb3.MaxLength = 3;
            this.sb3.Name = "sb3";
            this.sb3.Size = new System.Drawing.Size(32, 20);
            this.sb3.TabIndex = 10;
            this.sb3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.key);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(102, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(10, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = ".";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(48, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(10, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = ".";
            // 
            // sb2
            // 
            this.sb2.Location = new System.Drawing.Point(63, 0);
            this.sb2.MaxLength = 3;
            this.sb2.Name = "sb2";
            this.sb2.Size = new System.Drawing.Size(32, 20);
            this.sb2.TabIndex = 4;
            this.sb2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.key);
            // 
            // sb1
            // 
            this.sb1.Location = new System.Drawing.Point(10, 0);
            this.sb1.MaxLength = 3;
            this.sb1.Name = "sb1";
            this.sb1.Size = new System.Drawing.Size(32, 20);
            this.sb1.TabIndex = 3;
            this.sb1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.key);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.ip4);
            this.panel1.Controls.Add(this.ip3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.ip2);
            this.panel1.Controls.Add(this.ip1);
            this.panel1.Location = new System.Drawing.Point(6, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(209, 23);
            this.panel1.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(150, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = ".";
            // 
            // ip4
            // 
            this.ip4.Location = new System.Drawing.Point(166, 0);
            this.ip4.MaxLength = 3;
            this.ip4.Name = "ip4";
            this.ip4.Size = new System.Drawing.Size(32, 20);
            this.ip4.TabIndex = 11;
            this.ip4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.key);
            // 
            // ip3
            // 
            this.ip3.Location = new System.Drawing.Point(118, 0);
            this.ip3.MaxLength = 3;
            this.ip3.Name = "ip3";
            this.ip3.Size = new System.Drawing.Size(32, 20);
            this.ip3.TabIndex = 10;
            this.ip3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.key);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(102, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = ".";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = ".";
            // 
            // ip2
            // 
            this.ip2.Location = new System.Drawing.Point(63, 0);
            this.ip2.MaxLength = 3;
            this.ip2.Name = "ip2";
            this.ip2.Size = new System.Drawing.Size(32, 20);
            this.ip2.TabIndex = 4;
            this.ip2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.key);
            // 
            // ip1
            // 
            this.ip1.Location = new System.Drawing.Point(10, 0);
            this.ip1.MaxLength = 3;
            this.ip1.Name = "ip1";
            this.ip1.Size = new System.Drawing.Size(32, 20);
            this.ip1.TabIndex = 3;
            this.ip1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.key);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(221, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = " Default Gateway";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Subnet Mask";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(221, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "IP";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(250, 282);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // apply
            // 
            this.apply.Location = new System.Drawing.Point(98, 282);
            this.apply.Name = "apply";
            this.apply.Size = new System.Drawing.Size(142, 23);
            this.apply.TabIndex = 5;
            this.apply.Text = "Send setings to instrrument";
            this.apply.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(9, 163);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(315, 106);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Current setings";
            // 
            // INST_IP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 317);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.apply);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dhcp);
            this.Name = "INST_IP";
            this.Text = "INST_IP";
            this.Load += new System.EventHandler(this.INST_IP_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton dhcp;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button apply;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ip4;
        private System.Windows.Forms.TextBox ip3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ip2;
        private System.Windows.Forms.TextBox ip1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox gw4;
        private System.Windows.Forms.TextBox gw3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox gw2;
        private System.Windows.Forms.TextBox gw1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox sb4;
        private System.Windows.Forms.TextBox sb3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox sb2;
        private System.Windows.Forms.TextBox sb1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}