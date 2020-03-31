namespace Power_Supply_DashBoard
{
    partial class SCPI_terminal
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
            this.Returntb = new System.Windows.Forms.TextBox();
            this.CMD = new System.Windows.Forms.TextBox();
            this.Send = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Returntb
            // 
            this.Returntb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Returntb.HideSelection = false;
            this.Returntb.Location = new System.Drawing.Point(13, 13);
            this.Returntb.Multiline = true;
            this.Returntb.Name = "Returntb";
            this.Returntb.ReadOnly = true;
            this.Returntb.Size = new System.Drawing.Size(775, 403);
            this.Returntb.TabIndex = 0;
            // 
            // CMD
            // 
            this.CMD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CMD.Location = new System.Drawing.Point(13, 422);
            this.CMD.Name = "CMD";
            this.CMD.Size = new System.Drawing.Size(694, 20);
            this.CMD.TabIndex = 1;
            this.CMD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keydown);
            // 
            // Send
            // 
            this.Send.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Send.Location = new System.Drawing.Point(713, 422);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(75, 23);
            this.Send.TabIndex = 2;
            this.Send.Text = "Send";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // SCPI_terminal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.CMD);
            this.Controls.Add(this.Returntb);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "SCPI_terminal";
            this.Text = "SCPI terminal";
            this.Load += new System.EventHandler(this.load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Returntb;
        private System.Windows.Forms.TextBox CMD;
        private System.Windows.Forms.Button Send;
    }
}