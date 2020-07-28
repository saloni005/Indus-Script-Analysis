namespace IndusScriptGrouper
{
    partial class SelectInput
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
            this.lblExit = new System.Windows.Forms.Label();
            this.lblInputRandSamples = new System.Windows.Forms.Label();
            this.txbxSmplMx = new System.Windows.Forms.TextBox();
            this.lblSetDisplayWidth = new System.Windows.Forms.Label();
            this.txbxSymLine = new System.Windows.Forms.TextBox();
            this.lblInputSerialSamples = new System.Windows.Forms.Label();
            this.lbl4HistoCsvConvert = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblExit
            // 
            this.lblExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExit.AutoSize = true;
            this.lblExit.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExit.ForeColor = System.Drawing.Color.Blue;
            this.lblExit.Location = new System.Drawing.Point(848, 185);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(52, 29);
            this.lblExit.TabIndex = 2;
            this.lblExit.Text = "Exit";
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
            // 
            // lblInputRandSamples
            // 
            this.lblInputRandSamples.AutoSize = true;
            this.lblInputRandSamples.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInputRandSamples.ForeColor = System.Drawing.Color.Blue;
            this.lblInputRandSamples.Location = new System.Drawing.Point(12, 95);
            this.lblInputRandSamples.Name = "lblInputRandSamples";
            this.lblInputRandSamples.Size = new System.Drawing.Size(501, 29);
            this.lblInputRandSamples.TabIndex = 3;
            this.lblInputRandSamples.Text = "Select [NNN] Random Input Samples from Folder";
            this.lblInputRandSamples.Click += new System.EventHandler(this.lblInputRandSamples_Click);
            // 
            // txbxSmplMx
            // 
            this.txbxSmplMx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbxSmplMx.Location = new System.Drawing.Point(90, 99);
            this.txbxSmplMx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbxSmplMx.Name = "txbxSmplMx";
            this.txbxSmplMx.Size = new System.Drawing.Size(68, 26);
            this.txbxSmplMx.TabIndex = 4;
            this.txbxSmplMx.Text = "100";
            this.txbxSmplMx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSetDisplayWidth
            // 
            this.lblSetDisplayWidth.AutoSize = true;
            this.lblSetDisplayWidth.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSetDisplayWidth.ForeColor = System.Drawing.Color.Blue;
            this.lblSetDisplayWidth.Location = new System.Drawing.Point(12, 11);
            this.lblSetDisplayWidth.Name = "lblSetDisplayWidth";
            this.lblSetDisplayWidth.Size = new System.Drawing.Size(422, 29);
            this.lblSetDisplayWidth.TabIndex = 5;
            this.lblSetDisplayWidth.Text = "Set Display Width [NN]  Symbols  / Line";
            this.lblSetDisplayWidth.Click += new System.EventHandler(this.lblSetDisplayWidth_Click);
            // 
            // txbxSymLine
            // 
            this.txbxSymLine.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbxSymLine.Location = new System.Drawing.Point(213, 14);
            this.txbxSymLine.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbxSymLine.Name = "txbxSymLine";
            this.txbxSymLine.Size = new System.Drawing.Size(52, 26);
            this.txbxSymLine.TabIndex = 6;
            this.txbxSymLine.Text = "16";
            this.txbxSymLine.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblInputSerialSamples
            // 
            this.lblInputSerialSamples.AutoSize = true;
            this.lblInputSerialSamples.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInputSerialSamples.ForeColor = System.Drawing.Color.Blue;
            this.lblInputSerialSamples.Location = new System.Drawing.Point(12, 53);
            this.lblInputSerialSamples.Name = "lblInputSerialSamples";
            this.lblInputSerialSamples.Size = new System.Drawing.Size(446, 29);
            this.lblInputSerialSamples.TabIndex = 8;
            this.lblInputSerialSamples.Text = "Select All Serial Input Samples from Folder";
            this.lblInputSerialSamples.Click += new System.EventHandler(this.lblInputSerialSamples_Click);
            // 
            // lbl4HistoCsvConvert
            // 
            this.lbl4HistoCsvConvert.AutoSize = true;
            this.lbl4HistoCsvConvert.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl4HistoCsvConvert.ForeColor = System.Drawing.Color.Blue;
            this.lbl4HistoCsvConvert.Location = new System.Drawing.Point(15, 143);
            this.lbl4HistoCsvConvert.Name = "lbl4HistoCsvConvert";
            this.lbl4HistoCsvConvert.Size = new System.Drawing.Size(895, 29);
            this.lbl4HistoCsvConvert.TabIndex = 11;
            this.lbl4HistoCsvConvert.Text = "Convert [IndusFont1840Out3 All 70x54]=>IndusFont1840.CSV (H+V+De+Dw) (4)Histogram" +
    "";
            this.lbl4HistoCsvConvert.Click += new System.EventHandler(this.lbl4HistoCsvConvert_Click);
            // 
            // SelectInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 224);
            this.Controls.Add(this.lbl4HistoCsvConvert);
            this.Controls.Add(this.lblInputSerialSamples);
            this.Controls.Add(this.txbxSymLine);
            this.Controls.Add(this.lblSetDisplayWidth);
            this.Controls.Add(this.txbxSmplMx);
            this.Controls.Add(this.lblInputRandSamples);
            this.Controls.Add(this.lblExit);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SelectInput";
            this.Text = "Select Input Image Samples";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectInput_FormClosing);
            this.Shown += new System.EventHandler(this.SelectInput_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblExit;
        private System.Windows.Forms.Label lblInputRandSamples;
        private System.Windows.Forms.TextBox txbxSmplMx;
        private System.Windows.Forms.Label lblSetDisplayWidth;
        private System.Windows.Forms.TextBox txbxSymLine;
        private System.Windows.Forms.Label lblInputSerialSamples;
        private System.Windows.Forms.Label lbl4HistoCsvConvert;
    }
}